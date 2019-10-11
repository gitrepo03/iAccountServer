using iHotel.Entity.Identity;
using iHotel.Repository.Extensions.DbExtension;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iHotel.Repository.Helper
{
    public class IdentityAuth
    {

        public static LoggedInUserModel getLoggedInUserClames(IHotelDbContext _db)
        {
            ClaimsIdentity clamesIdentity = (ClaimsIdentity)_db._httpContextAccessor.HttpContext.User?.Identity;
            LoggedInUserModel loggedUser = new LoggedInUserModel();

            loggedUser.UserId = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "UserID")?.Value;
            loggedUser.UserName = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "UserName")?.Value;
            loggedUser.UserEmail = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "Email")?.Value;
            loggedUser.Organization = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "Organization")?.Value;

            return loggedUser;
        }

        public static List<string> getLoggedInUsersRole(IHotelDbContext _db, string userId)
        {
            IQueryable<string> userRoles = from a in _db.UserRoles
                                   join r in _db.Roles
                                   on a.RoleId equals r.Id
                                   where a.UserId == userId
                                           select r.Name;
            return userRoles.ToList();
        }
    }
}
