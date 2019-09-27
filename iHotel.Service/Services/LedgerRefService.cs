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
    public class LedgerRefService: ILedgerRefService
    {
        private readonly IRepository<LedgerRef> repo;

        public LedgerRefService(IRepository<LedgerRef> repo)
        {
            this.repo = repo;
        }

        public Task<int> CountAsync()
        {
            return this.repo.CountAsync();
        }

        public Task<LedgerRef> CreateAsync(LedgerRef entity)
        {
            return this.repo.CreateAsync(entity);
        }

        public Task<List<LedgerRef>> CreateRangeAsync(List<LedgerRef> entities)
        {
            return this.repo.CreateRangeAsync(entities);
        }

        public Task<LedgerRef> DeleteAsync(int id)
        {
            return this.repo.DeleteAsync(id);
        }

        public Task<List<LedgerRef>> DeleteRangeAsync(List<int> ids)
        {
            return this.repo.DeleteRangeAsync(ids);
        }

        public IQueryable<LedgerRef> Get()
        {
            return this.repo.Get();
        }

        public IQueryable<LedgerRef> GetAll()
        {
            return this.repo.GetAll();
        }

        public Task<LedgerRef> GetAsync(int id)
        {
            return this.repo.GetAsync(id);
        }

        public Task<LedgerRef> InactivateAsync(int id)
        {
            return this.repo.InactivateAsync(id);
        }

        public Task<List<LedgerRef>> InactivateRangeAsync(List<int> ids)
        {
            return this.repo.InactivateRangeAsync(ids);
        }

        public Task<LedgerRef> UpdateAsync(LedgerRef entity)
        {
            return this.repo.UpdateAsync(entity);
        }

        public Task<List<LedgerRef>> UpdateRangeAsync(List<LedgerRef> entities)
        {
            return this.repo.UpdateRangeAsync(entities);
        }
    }
}
