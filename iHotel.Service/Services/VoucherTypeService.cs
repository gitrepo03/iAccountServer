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
    public class VoucherTypeService: IVoucherTypeService
    {
        private readonly IRepository<VoucherType> repo;

        public VoucherTypeService(IRepository<VoucherType> repo)
        {
            this.repo = repo;
        }

        public Task<int> CountAsync()
        {
            return this.repo.CountAsync();
        }

        public Task<VoucherType> CreateAsync(VoucherType entity)
        {
            return this.repo.CreateAsync(entity);
        }

        public Task<List<VoucherType>> CreateRangeAsync(List<VoucherType> entities)
        {
            return this.repo.CreateRangeAsync(entities);
        }

        public Task<VoucherType> DeleteAsync(int id)
        {
            return this.repo.DeleteAsync(id);
        }

        public Task<List<VoucherType>> DeleteRangeAsync(List<int> ids)
        {
            return this.repo.DeleteRangeAsync(ids);
        }

        public IQueryable<VoucherType> Get()
        {
            return this.repo.Get();
        }

        public IQueryable<VoucherType> GetAll()
        {
            return this.repo.GetAll();
        }

        public Task<VoucherType> GetAsync(int id)
        {
            return this.repo.GetAsync(id);
        }

        public Task<VoucherType> InactivateAsync(int id)
        {
            return this.repo.InactivateAsync(id);
        }

        public Task<List<VoucherType>> InactivateRangeAsync(List<int> ids)
        {
            return this.repo.InactivateRangeAsync(ids);
        }

        public Task<VoucherType> UpdateAsync(VoucherType entity)
        {
            return this.repo.UpdateAsync(entity);
        }

        public Task<List<VoucherType>> UpdateRangeAsync(List<VoucherType> entities)
        {
            return this.repo.UpdateRangeAsync(entities);
        }
    }
}
