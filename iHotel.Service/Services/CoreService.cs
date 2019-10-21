using iHotel.Entity.Common;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.Helper;
using iHotel.Repository.RepoInterface;
using iHotel.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Service.Services
{
    public class CoreService<T> : ICoreService<T> where T : BaseEntity
    {
        private readonly IRepository<T> repo;
        private int usersOrg;

        public CoreService(IRepository<T> repo)
        {
            this.repo = repo;
            usersOrg = int.Parse(repo.UsersClame().Organization);
        }

        public Task<int> CountAsync()
        {
            return this.repo.CountAsync();
        }

        public Task<T> CreateAsync(T entity)
        {
            return this.repo.CreateAsync(entity);
        }

        public Task<List<T>> CreateRangeAsync(List<T> entities)
        {
            return this.repo.CreateRangeAsync(entities);
        }

        public Task<T> DeleteAsync(int id)
        {
            return this.repo.DeleteAsync(id);
        }

        public Task<List<T>> DeleteRangeAsync(List<int> ids)
        {
            return this.repo.DeleteRangeAsync(ids);
        }

        public Task<T> InactivateAsync(int id)
        {
            return this.repo.InactivateAsync(id);
        }

        public Task<List<T>> InactivateRangeAsync(List<int> ids)
        {
            return this.repo.InactivateRangeAsync(ids);
        }

        public Task<T> UpdateAsync(T entity)
        {
            return this.repo.UpdateAsync(entity);
        }

        public Task<List<T>> UpdateRangeAsync(List<T> entities)
        {
            return this.repo.UpdateRangeAsync(entities);
        }


        //====================================================================================================

        public IQueryable<T> GetAll()
        {
            return this.repo.GetAll();
        }

        public IQueryable<T> GetAllActive()
        {
            return this.repo.Get();
        }

        public IQueryable<T> GetAllOfOrg()
        {
            return this.repo.GetAll().Where(f => f.Organization == usersOrg);
        }

        public IQueryable<T> GetAllActiveOfOrg()
        {
            return this.repo.GetAll().Where(f => f.Organization == usersOrg && f.IsActive);
        }

        public IQueryable<T> GetById(int id)
        {
            return this.repo.GetById(id);
        }
    }
}
