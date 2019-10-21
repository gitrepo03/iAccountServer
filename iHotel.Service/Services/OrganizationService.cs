using iHotel.Entity.Admin;
using iHotel.Repository.RepoInterface;
using iHotel.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Service.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organization> repo;

        public OrganizationService(IRepository<Organization> repo)
        {
            this.repo = repo;
        }

        public async Task<int> CountAsync()
        {
            return await repo.CountAsync();
        }

        public async Task<Organization> CreateAsync(Organization entity)
        {
            return await repo.CreateAsync(entity);
        }

        public async Task<List<Organization>> CreateRangeAsync(List<Organization> entities)
        {
            return await repo.CreateRangeAsync(entities);
        }

        public async Task<Organization> DeleteAsync(int id)
        {
            return await repo.DeleteAsync(id);
        }

        public async Task<List<Organization>> DeleteRangeAsync(List<int> ids)
        {
            return await repo.DeleteRangeAsync(ids);
        }

        public IQueryable<Organization> Get()
        {
            return repo.Get();
        }

        public IQueryable<Organization> GetAll()
        {
            return repo.GetAll();
        }

        public IQueryable<Organization> GetById(int id)
        {
            return repo.GetById(id);
        }

        public async Task<Organization> InactivateAsync(int id)
        {
            return await repo.InactivateAsync(id);
        }

        public async Task<List<Organization>> InactivateRangeAsync(List<int> ids)
        {
            return await repo.InactivateRangeAsync(ids);
        }

        public async Task<Organization> UpdateAsync(Organization entity)
        {
            return await repo.UpdateAsync(entity);
        }

        public async Task<List<Organization>> UpdateRangeAsync(List<Organization> entities)
        {
            return await repo.UpdateRangeAsync(entities);
        }
    }
}
