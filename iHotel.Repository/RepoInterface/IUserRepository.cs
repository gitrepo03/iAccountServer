using iHotel.Entity.Identity;
using iHotel.Repository.Extensions.DbExtension;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Repository.RepoInterface
{
    public interface IUserRepository
    {
        LoggedInUserModel UsersClames();
        Task<List<String>> UsersRoles(string userId);
    }
}
