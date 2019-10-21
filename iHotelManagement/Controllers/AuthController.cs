using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iHotel.Entity.Identity;
using iHotel.Repository.Helper;
using iHotel.Service.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace iHotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        // Post: api/SuperAdminDeveloperRegister
        [HttpPost]
        [Route("SADRegister")]
        [Authorize(Roles = "SuperAdminDeveloper")]
        public async Task<IActionResult> SADRegister([FromBody] UserModel model)
        {
            return await registerAction(model);
        }

        // Post: api/Register
        [HttpPost]
        [Route("Register")]
        [Authorize]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            model.Organization = int.Parse(authService.GetLoggedInUserClames().Organization);
            return await registerAction(model);
        }

        // Post: api/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                string token = await authService.LoginAsync(model);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        // POST: api/Auth
        [HttpPost]
        [Route("Role")]
        [Authorize(Roles = "SuperAdminDeveloper")]
        public async Task<IActionResult> Post([FromBody] string role)
        {
            try
            {
                IdentityRole generatedRole = await authService.CreateRoleAsync(role);
                return Ok(generatedRole);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        [HttpGet]
        [Route("AccountVerification")]
        public async Task<IActionResult> Post([FromQuery] string userId, string token)
        {
            try
            {
                if (await authService.AccountVerificationAsync(userId, token))
                {
                    return Ok("Account verification successful.");
                }
                return BadRequest("Problem during account verification process.");
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        [HttpPost]
        [Route("PasswordReset")]
        public async Task<IActionResult> PasswordResetAsync([FromBody] PasswordResetRequest passReset)
        {
            try
            {
                if (await authService.PasswordResetRequestAsync(passReset))
                {
                    return Ok("Password reset link has been sent to your email address!");
                }
                return BadRequest("Problem while sending password reset link. Please try again later");
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> Post([FromBody] ResetPasswordViewModel resetPassVM)
        {
            try
            {
                if (await authService.ResetPasswordAsync(resetPassVM))
                {
                    return Ok("Password reset successful!");
                }
                return BadRequest("Error while resetting the password!");
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }
        }

        private async Task<IActionResult> registerAction(UserModel model)
        {
            RegisterResponseModel resp = new RegisterResponseModel();
            try
            {
                resp = await authService.RegisterAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ExceptionHandler.AbstractExceptionMessage(ex));
            }

            if (!resp.NewUserResult.Succeeded)
            {
                string errorMessage = "";
                foreach (var error in resp.NewUserResult.Errors)
                {
                    errorMessage += error.Description + "\n";
                }
                return BadRequest("Error occured while registering new user." + errorMessage);
            }
            if (!resp.RoleAddResult.Succeeded)
            {
                string errorMessage = "";
                foreach (var error in resp.NewUserResult.Errors)
                {
                    errorMessage += error.Description + "\n";
                }
                return BadRequest("Error occured while assigning role to new user." + errorMessage);
            }
            if (!resp.SentAccVerfCodeSucceed)
            {
                return BadRequest("Error while sending email verification code.");
            }

            return Ok(new
            {
                success = true,
                errors = 0,
                successMessage = "New user created successfully"
            });
        }
    }
}
