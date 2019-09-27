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
    public class AccountRefService: IAccountRefService
    {
        private readonly IRepository<AccountRef> repo;

        public AccountRefService(IRepository<AccountRef> repo)
        {
            this.repo = repo;
        }

        public Task<int> CountAsync()
        {
            return this.repo.CountAsync();
        }

        public Task<AccountRef> CreateAsync(AccountRef entity)
        {
            return this.repo.CreateAsync(entity);
        }

        public Task<List<AccountRef>> CreateRangeAsync(List<AccountRef> entities)
        {
            return this.repo.CreateRangeAsync(entities);
        }

        public Task<AccountRef> DeleteAsync(int id)
        {
            return this.repo.DeleteAsync(id);
        }

        public Task<List<AccountRef>> DeleteRangeAsync(List<int> ids)
        {
            return this.repo.DeleteRangeAsync(ids);
        }

        public IQueryable<AccountRef> Get()
        {
            return this.repo.Get();
        }

        public IQueryable<AccountRef> GetAll()
        {
            return this.repo.GetAll();
        }

        public Task<AccountRef> GetAsync(int id)
        {
            return this.repo.GetAsync(id);
        }

        public Task<AccountRef> InactivateAsync(int id)
        {
            return this.repo.InactivateAsync(id);
        }

        public Task<List<AccountRef>> InactivateRangeAsync(List<int> ids)
        {
            return this.repo.InactivateRangeAsync(ids);
        }

        public Task<AccountRef> UpdateAsync(AccountRef entity)
        {
            return this.repo.UpdateAsync(entity);
        }

        public Task<List<AccountRef>> UpdateRangeAsync(List<AccountRef> entities)
        {
            return this.repo.UpdateRangeAsync(entities);
        }
    }
}
