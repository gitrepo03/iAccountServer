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
    public class VoucherDetailService: IVoucherDetailService
    {
        private readonly IRepository<VoucherDetail> repo;

        public VoucherDetailService(IRepository<VoucherDetail> repo)
        {
            this.repo = repo;
        }

        public Task<int> CountAsync()
        {
            return this.repo.CountAsync();
        }

        public Task<VoucherDetail> CreateAsync(VoucherDetail entity)
        {
            return this.repo.CreateAsync(entity);
        }

        public Task<List<VoucherDetail>> CreateRangeAsync(List<VoucherDetail> entities)
        {
            return this.repo.CreateRangeAsync(entities);
        }

        public Task<VoucherDetail> DeleteAsync(int id)
        {
            return this.repo.DeleteAsync(id);
        }

        public Task<List<VoucherDetail>> DeleteRangeAsync(List<int> ids)
        {
            return this.repo.DeleteRangeAsync(ids);
        }

        public IQueryable<VoucherDetail> Get()
        {
            return this.repo.Get();
        }

        public IQueryable<VoucherDetail> GetAll()
        {
            return this.repo.GetAll();
        }

        public Task<VoucherDetail> GetAsync(int id)
        {
            return this.repo.GetAsync(id);
        }

        public Task<VoucherDetail> InactivateAsync(int id)
        {
            return this.repo.InactivateAsync(id);
        }

        public Task<List<VoucherDetail>> InactivateRangeAsync(List<int> ids)
        {
            return this.repo.InactivateRangeAsync(ids);
        }

        public Task<VoucherDetail> UpdateAsync(VoucherDetail entity)
        {
            return this.repo.UpdateAsync(entity);
        }

        public Task<List<VoucherDetail>> UpdateRangeAsync(List<VoucherDetail> entities)
        {
            return this.repo.UpdateRangeAsync(entities);
        }
    }
}
