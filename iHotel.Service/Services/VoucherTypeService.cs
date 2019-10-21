using iHotel.Entity.Accounting;
using iHotel.Entity.Common;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using iHotel.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Service.Services
{
    public class VoucherTypeService : CoreService<VoucherType>, IVoucherTypeService
    {
        private readonly IReadRepository<WriteActivityLog> _walRepo;
        public VoucherTypeService(IRepository<VoucherType> repo, IReadRepository<WriteActivityLog> walRepo) : base(repo)
        {
            _walRepo = walRepo;
        }

        IQueryable<VoucherType_R> ICoreService_R<VoucherType_R>.GetAll()
        {
            return createReadDataAsync(this.GetAll());
        }

        IQueryable<VoucherType_R> ICoreService_R<VoucherType_R>.GetAllOfOrg()
        {
            return createReadDataAsync(this.GetAllOfOrg());
        }

        IQueryable<VoucherType_R> ICoreService_R<VoucherType_R>.GetById(int id)
        {
            return createReadDataAsync(this.GetById(id));
        }

        private IQueryable<VoucherType_R> createReadDataAsync(IQueryable<VoucherType> source)
        {

            return from vt in source
                    join w in _walRepo.GetAll()
                    on vt.AudId equals w.AudId
                    into lj_w
                    from w in lj_w.Where(w => w.ActivityTable == "VoucherType").DefaultIfEmpty()
                    select new VoucherType_R()
                    {
                        Id = vt.Id,
                        AudId = vt.AudId,
                        VoucherCode = vt.VoucherCode,
                        VoucherName = vt.VoucherName,
                        IsActive = vt.IsActive,
                        Organization = vt.Organization,
                        User = vt.User,
                        OrgName = vt.OrganizationNavigation.OrgName,
                        C_User = w.User,
                        C_On_AD = w.DateAd.GetValueOrDefault().ToShortDateString(),
                        C_On_BS = w.DateBs
                    };

        }


        //private readonly IRepository<VoucherType> repo;

        //public VoucherTypeService(IRepository<VoucherType> repo)
        //{
        //    this.repo = repo;
        //}

        //public Task<int> CountAsync()
        //{
        //    return this.repo.CountAsync();
        //}

        //public Task<VoucherType> CreateAsync(VoucherType entity)
        //{
        //    return this.repo.CreateAsync(entity);
        //}

        //public Task<List<VoucherType>> CreateRangeAsync(List<VoucherType> entities)
        //{
        //    return this.repo.CreateRangeAsync(entities);
        //}

        //public Task<VoucherType> DeleteAsync(int id)
        //{
        //    return this.repo.DeleteAsync(id);
        //}

        //public Task<List<VoucherType>> DeleteRangeAsync(List<int> ids)
        //{
        //    return this.repo.DeleteRangeAsync(ids);
        //}

        //public IQueryable<VoucherType> Get()
        //{
        //    return this.repo.Get();
        //}

        //public IQueryable<VoucherType> GetAll()
        //{
        //    return this.repo.GetAll();
        //}

        //public Task<VoucherType> GetAsync(int id)
        //{
        //    return this.repo.GetAsync(id);
        //}

        //public Task<VoucherType> InactivateAsync(int id)
        //{
        //    return this.repo.InactivateAsync(id);
        //}

        //public Task<List<VoucherType>> InactivateRangeAsync(List<int> ids)
        //{
        //    return this.repo.InactivateRangeAsync(ids);
        //}

        //public Task<VoucherType> UpdateAsync(VoucherType entity)
        //{
        //    return this.repo.UpdateAsync(entity);
        //}

        //public Task<List<VoucherType>> UpdateRangeAsync(List<VoucherType> entities)
        //{
        //    return this.repo.UpdateRangeAsync(entities);
        //}

    }
}
