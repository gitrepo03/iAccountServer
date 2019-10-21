using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Repository.RepoInterface
{
    public interface IRepository<T>: IReadRepository<T>
    {
        //Count total Active data from database.
        Task<int> CountAsync();
        //Insert a single data to table.
        Task<T> CreateAsync(T entity);
        //Insert a range of data to table.
        Task<List<T>> CreateRangeAsync(List<T> entities);
        //Update(Edit) a single data in table.
        Task<T> UpdateAsync(T entity);
        //Update(Edit) a range of data in table.
        Task<List<T>> UpdateRangeAsync(List<T> entities);
        //Inactivate a single data by id.
        Task<T> InactivateAsync(int id);
        //Inactivate a range of data by ids.
        Task<List<T>> InactivateRangeAsync(List<int> ids);
        //Delete a single data by id.
        Task<T> DeleteAsync(int id);
        //Delete a range of data by ids.
        Task<List<T>> DeleteRangeAsync(List<int> ids);
        //Get LoggedInUsers Clames Detail.
        LoggedInUserModel UsersClame();
        //Get Roles of a User.
        List<string> UsersRoles(string userId);
    }
}
