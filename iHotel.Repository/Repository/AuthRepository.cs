using iHotel.Entity.Admin;
using iHotel.Entity.Identity;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.Helper;
using iHotel.Repository.RepoInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iHotel.Repository.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSetting _appSettings;
        private readonly IEmailSender _emailSender;
        private readonly IHotelDbContext _db;

        public AuthRepository(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSetting> appSettings,
            IEmailSender emailSender,
            IHotelDbContext context
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
            _emailSender = emailSender;
            _db = context;
        }

        public async Task<string> LoginAsync(LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if(user == null)
                {
                    user = await _userManager.FindByEmailAsync(model.UserName);
                }
                if(user == null)
                {
                    //TODO: Implement logic to login using phone number.
                }

                Organization org = isUserInOrgExist(model.OrganizationCode, user);
                if (org != null)
                {
                    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                        IdentityOptions _options = new IdentityOptions();
                        var roles = await _userManager.GetRolesAsync(user);
                        var clames = new ClaimsIdentity(new Claim[]
                            {
                            new Claim("UserID",user.Id),
                            new Claim("UserName", user.UserName),
                            new Claim("Email", user.Email),
                            new Claim("Organization", org.ToString())
                                //new Claim(_options.ClaimsIdentity.RoleClaimType, roles.FirstOrDefault()),
                            });
                        clames.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                        var expireTime = DateTime.UtcNow.AddDays(1);
                        SigningCredentials cred = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = clames,
                            Expires = expireTime,
                            SigningCredentials = cred
                        };
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                        var token = tokenHandler.WriteToken(securityToken);
                        return token;
                    }
                    else
                        throw new InvalidDataException("Username or password is incorrect.");
                }
                else
                {
                    throw new InvalidDataException("User doesnot exist in organization with organization Code '"+model.OrganizationCode+"'");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RegisterResponseModel> RegisterAsync(UserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
            };

            try
            {
                IdentityResult roleRes = new IdentityResult();
                bool isAccountVerificationMailSendSucceed = false;

                IdentityResult result = await _userManager.CreateAsync(applicationUser, model.Password);

                

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("SuperAdminDeveloper").Result)
                    {
                        await CreateRoleAsync("SuperAdminDeveloper");
                        //var createRoleRes = await _roleManager.CreateAsync(new IdentityRole()
                        //{
                        //    Name = "SuperAdminDeveloper"
                        //});
                    }
                    roleRes = await _userManager.AddToRoleAsync(applicationUser, "SuperAdminDeveloper");
                }

                if (result.Succeeded && roleRes.Succeeded)
                {
                    ApplicationUser newlyCreatedUser = new ApplicationUser()
                    {
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        UserName = model.UserName,
                        FullName = model.FullName
                    };
                    ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
                    await createUsersOrgs(model.Organization, user.Id);

                    isAccountVerificationMailSendSucceed = await sendAccountVerificationCodeAsync(applicationUser);
                }

                return new RegisterResponseModel
                {
                    NewUserResult = result,
                    RoleAddResult = roleRes,
                    SentAccVerfCodeSucceed = isAccountVerificationMailSendSucceed
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityRole> CreateRoleAsync(string role)
        {
            if (role == null || role == "")
            {
                throw new ArgumentNullException("Role is required to create a role");
            }
            if (_roleManager.RoleExistsAsync(role).Result)
            {
                throw new InvalidDataException($"Role with name {role} alrady exist");
            }
            IdentityRole roleToCreate = new IdentityRole()
            {
                Name = role
            };
            var roleCrateRes = await _roleManager.CreateAsync(roleToCreate);

            if (!roleCrateRes.Succeeded)
            {
                throw new Exception("Some unknown error occured while creating the role.");
            }
            return roleToCreate;
        }

        public async Task<bool> AccountVerificationAsync(string userId, string token)
        {
            if (userId == null || token == null)
            {
                throw new ArgumentNullException("UserId and Verification token is required");
            }
            //ApplicationUser user = _userManager.FindByIdAsync(userId).Result;
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new InvalidDataException("User not found!");
            }
            //IdentityResult result = _userManager.ConfirmEmailAsync(user, token).result;
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Email conformation token is not valid!");
            }
            return true;
        }

        public async Task<bool> PasswordResetRequestAsync(PasswordResetRequest passReset)
        {
            ApplicationUser user = _userManager.FindByNameAsync(passReset.email).Result;
            bool isEmailConformed = _userManager.IsEmailConfirmedAsync(user).Result;
            //if (user == null || !isEmailConformed)
            if (user == null)
            {
                throw new InvalidDataException("Error while resetting your password!. User with Email '" + passReset.email + "' doesnot exist.");
            }
            if (!isEmailConformed)
            {
                throw new InvalidOperationException("Your account is not verified. In order to reset your password you must verify your account.");
            }
            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            var encodedToken = HttpUtility.UrlEncode(token);
            var encodedUserId = HttpUtility.UrlEncode(user.Id);

            //var resetLink = Url.Action("ResetPassword", "ApplicationUser", new { token = token },
            //         protocol: HttpContext.Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Password Reset", $"<a href='{_appSettings.PasswordResetURL}/{encodedUserId}/{encodedToken}'>Click here to reset your password</a>");

            return true;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordViewModel resetPassVM)
        {
            //ApplicationUser user = _userManager.
            //     FindByIdAsync(resetPassVM.UserId).Result;

            ApplicationUser user = await _userManager.
                 FindByIdAsync(resetPassVM.UserId);

            if (user == null)
                throw new InvalidDataException("User doesnot exist!");

            IdentityResult result = _userManager.ResetPasswordAsync
                      (user, resetPassVM.Token, resetPassVM.Password).Result;
            if (result.Succeeded)
            {
                return true;
            }
            throw new Exception("Error while resetting the password!");
        }

        private async Task<bool> sendAccountVerificationCodeAsync(ApplicationUser user)
        {
            try
            {
                if (_userManager.FindByIdAsync(user.Id).Result == null)
                {
                    return false;
                }
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedUserId = HttpUtility.UrlEncode(user.Id);
                var encodedToken = HttpUtility.UrlEncode(token);

                var conformationLink = $"{ _appSettings.AccountConformationURL }?userId={encodedUserId}&token={encodedToken}";

                await _emailSender.SendEmailAsync(user.Email, "Account Verification", $"<a href='{conformationLink}'>Click here to activate/conform your account</a>");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Organization isUserInOrgExist(string orgCode, ApplicationUser user)
        {
            Organization org = _db.Organizations.SingleOrDefault(o => o.OrgCode == orgCode);
            if(org == null)
            {
                throw new InvalidDataException("Organization with organization code '" + orgCode + "' don\'t exist");
            }

            UsersOrgs userOrgs = _db.UsersOrgs.SingleOrDefault(uo => uo.Organization == org.Id && uo.User == user.Id);
            if(userOrgs != null)
            {
                return org;
            }
            return null;
        }

        public async Task<bool> createUsersOrgs(int org, string user)
        {
            UsersOrgs usersOrg = new UsersOrgs()
            {
                Organization = org,
                User = user
            };

            _db.Add(usersOrg);
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public LoggedInUserModel GetLoggedInUserClames()
        {
            return new IdentityAuth(_db).getLoggedInUserClames();
        }
    }
}
