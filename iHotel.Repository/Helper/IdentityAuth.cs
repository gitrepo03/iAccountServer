using iHotel.Entity.Identity;
using iHotel.Repository.Extensions.DbExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace iHotel.Repository.Helper
{
    public class IdentityAuth
    {
        private readonly IHotelDbContext _db;
        public IdentityAuth(IHotelDbContext context)
        {
            _db = context;
        }

        public LoggedInUserModel getLoggedInUserClames()
        {
            ClaimsIdentity clamesIdentity = (ClaimsIdentity)_db._httpContextAccessor.HttpContext.User?.Identity;
            LoggedInUserModel loggedUser = new LoggedInUserModel();

            loggedUser.UserId = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "UserID")?.Value;
            loggedUser.UserName = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "UserName")?.Value;
            loggedUser.UserEmail = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "Email")?.Value;
            loggedUser.Organization = clamesIdentity.Claims.SingleOrDefault(c => c.Type == "Organization")?.Value;

            return loggedUser;
        }
    }
}
