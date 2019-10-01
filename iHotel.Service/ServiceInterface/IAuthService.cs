using iHotel.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Service.ServiceInterface
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel model);
        Task<RegisterResponseModel> RegisterAsync(UserModel model);
        Task<IdentityRole> CreateRoleAsync(string role);
        Task<bool> AccountVerificationAsync(string userId, string token);
        Task<bool> PasswordResetRequestAsync(PasswordResetRequest passReset);
        Task<bool> ResetPasswordAsync(ResetPasswordViewModel resetPassVM);
        LoggedInUserModel GetLoggedInUserClames();
    }
}
