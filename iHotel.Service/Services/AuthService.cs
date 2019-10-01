using iHotel.Entity.Identity;
using iHotel.Repository.RepoInterface;
using iHotel.Service.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepo;

        public AuthService(IAuthRepository authRepo)
        {
            this.authRepo = authRepo;
        }

        public async Task<bool> AccountVerificationAsync(string userId, string token)
        {
            return await authRepo.AccountVerificationAsync(userId, token);
        }

        public async Task<IdentityRole> CreateRoleAsync(string role)
        {
            return await authRepo.CreateRoleAsync(role);
        }

        public LoggedInUserModel GetLoggedInUserClames()
        {
            return authRepo.GetLoggedInUserClames();
        }

        public async Task<string> LoginAsync(LoginModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Argument null exception. UserName and Password is required.");
            }
            return await authRepo.LoginAsync(model);
        }

        public async Task<bool> PasswordResetRequestAsync(PasswordResetRequest passReset)
        {
            return await authRepo.PasswordResetRequestAsync(passReset);
        }

        public async Task<RegisterResponseModel> RegisterAsync(UserModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Argument null exception. User information is required to register new user.");
            }
            return await authRepo.RegisterAsync(model);
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordViewModel resetPassVM)
        {
            return await authRepo.ResetPasswordAsync(resetPassVM);
        }
    }
}
