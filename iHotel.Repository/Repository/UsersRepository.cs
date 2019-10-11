using iHotel.Entity.Identity;
using iHotel.Repository.RepoInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Repository.Repository
{
    public class UsersRepository : IUserRepository
    {
        private UserManager<ApplicationUser> _userManager;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public UsersRepository(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
    }

        public LoggedInUserModel UsersClames()
        {
            ClaimsIdentity clamesIdentity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User?.Identity;
            LoggedInUserModel loggedUser = new LoggedInUserModel();

            loggedUser.UserId = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "UserID")?.Value;
            loggedUser.UserName = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "UserName")?.Value;
            loggedUser.UserEmail = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "Email")?.Value;
            loggedUser.Organization = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "Organization")?.Value;

            return loggedUser;
        }

        public async Task<List<string>> UsersRoles(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToList();
        }
    }
}
