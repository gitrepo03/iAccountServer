using iHotel.Entity.Accounting;
using iHotel.Repository.RepoInterface;
using iHotel.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Service.Services
{
    public class FiscalService : IFiscalService
    {
        private readonly IRepository<FiscalYear> repo;

        public FiscalService(IRepository<FiscalYear> repo)
        {
            this.repo = repo;
        }

        public Task<int> CountAsync()
        {
            return this.repo.CountAsync();
        }

        public Task<FiscalYear> CreateAsync(FiscalYear entity)
        {
            return this.repo.CreateAsync(entity);
        }

        public Task<List<FiscalYear>> CreateRangeAsync(List<FiscalYear> entities)
        {
            return this.repo.CreateRangeAsync(entities);
        }

        public Task<FiscalYear> DeleteAsync(int id)
        {
            return this.repo.DeleteAsync(id);
        }

        public Task<List<FiscalYear>> DeleteRangeAsync(List<int> ids)
        {
            return this.repo.DeleteRangeAsync(ids);
        }

        public IQueryable<FiscalYear> Get()
        {
            return this.repo.Get();
        }

        public IQueryable<FiscalYear> GetAll()
        {
            return this.repo.GetAll();
        }

        public Task<FiscalYear> GetAsync(int id)
        {
            return this.repo.GetAsync(id);
        }

        public Task<FiscalYear> InactivateAsync(int id)
        {
            return this.repo.InactivateAsync(id);
        }

        public Task<List<FiscalYear>> InactivateRangeAsync(List<int> ids)
        {
            return this.repo.InactivateRangeAsync(ids);
        }

        public Task<FiscalYear> UpdateAsync(FiscalYear entity)
        {
            return this.repo.UpdateAsync(entity);
        }

        public Task<List<FiscalYear>> UpdateRangeAsync(List<FiscalYear> entities)
        {
            return this.repo.UpdateRangeAsync(entities);
        }
    }
}
