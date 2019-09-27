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
    public class VoucherMasterService: IVoucherMasterService
    {
        private readonly IRepository<VoucherMaster> repo;

        public VoucherMasterService(IRepository<VoucherMaster> repo)
        {
            this.repo = repo;
        }

        public Task<int> CountAsync()
        {
            return this.repo.CountAsync();
        }

        public Task<VoucherMaster> CreateAsync(VoucherMaster entity)
        {
            return this.repo.CreateAsync(entity);
        }

        public Task<List<VoucherMaster>> CreateRangeAsync(List<VoucherMaster> entities)
        {
            return this.repo.CreateRangeAsync(entities);
        }

        public Task<VoucherMaster> DeleteAsync(int id)
        {
            return this.repo.DeleteAsync(id);
        }

        public Task<List<VoucherMaster>> DeleteRangeAsync(List<int> ids)
        {
            return this.repo.DeleteRangeAsync(ids);
        }

        public IQueryable<VoucherMaster> Get()
        {
            return this.repo.Get();
        }

        public IQueryable<VoucherMaster> GetAll()
        {
            return this.repo.GetAll();
        }

        public Task<VoucherMaster> GetAsync(int id)
        {
            return this.repo.GetAsync(id);
        }

        public Task<VoucherMaster> InactivateAsync(int id)
        {
            return this.repo.InactivateAsync(id);
        }

        public Task<List<VoucherMaster>> InactivateRangeAsync(List<int> ids)
        {
            return this.repo.InactivateRangeAsync(ids);
        }

        public Task<VoucherMaster> UpdateAsync(VoucherMaster entity)
        {
            return this.repo.UpdateAsync(entity);
        }

        public Task<List<VoucherMaster>> UpdateRangeAsync(List<VoucherMaster> entities)
        {
            return this.repo.UpdateRangeAsync(entities);
        }
    }
}
