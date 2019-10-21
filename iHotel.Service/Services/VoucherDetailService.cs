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
    public class VoucherDetailService : CoreService<VoucherDetail>, IVoucherDetailService
    {
        private readonly IReadRepository<WriteActivityLog> _walRepo;
        public VoucherDetailService(IRepository<VoucherDetail> repo, IReadRepository<WriteActivityLog> walRepo) : base(repo)
        {
            _walRepo = walRepo;
        }

        IQueryable<VoucherDetail_R> ICoreService_R<VoucherDetail_R>.GetAll()
        {
            return createReadDataAsync(this.GetAll());
        }

        IQueryable<VoucherDetail_R> ICoreService_R<VoucherDetail_R>.GetAllOfOrg()
        {
            return createReadDataAsync(this.GetAllOfOrg());
        }

        IQueryable<VoucherDetail_R> ICoreService_R<VoucherDetail_R>.GetById(int id)
        {
            return createReadDataAsync(this.GetById(id));
        }

        private IQueryable<VoucherDetail_R> createReadDataAsync(IQueryable<VoucherDetail> source)
        {

            return from vd in source
                    join w in _walRepo.GetAll()
                    on vd.AudId equals w.AudId
                    into lj_w
                    from w in lj_w.Where(w => w.ActivityTable == "VoucherDetail").DefaultIfEmpty()
                    select new VoucherDetail_R()
                    {
                        Id = vd.Id,
                        AudId = vd.AudId,
                        VoucherNumber = vd.VoucherNumber,
                        VoucherCode = vd.VoucherCode,
                        SerialNumber = vd.SerialNumber,
                        LedgerCode = vd.LedgerCode,
                        BalanceType = vd.BalanceType,
                        Amount = vd.Amount,
                        Description = vd.Description,
                        IsActive = vd.IsActive,
                        Organization = vd.Organization,
                        User = vd.User,
                        FiscalYear = vd.FiscalYear,
                        OrgName = vd.OrganizationNavigation.OrgName,
                        C_User = w.User,
                        C_On_AD = w.DateAd.GetValueOrDefault().ToShortDateString(),
                        C_On_BS = w.DateBs
                    };

            //private readonly IRepository<VoucherDetail> repo;

            //public VoucherDetailService(IRepository<VoucherDetail> repo)
            //{
            //    this.repo = repo;
            //}

            //public Task<int> CountAsync()
            //{
            //    return this.repo.CountAsync();
            //}

            //public Task<VoucherDetail> CreateAsync(VoucherDetail entity)
            //{
            //    return this.repo.CreateAsync(entity);
            //}

            //public Task<List<VoucherDetail>> CreateRangeAsync(List<VoucherDetail> entities)
            //{
            //    return this.repo.CreateRangeAsync(entities);
            //}

            //public Task<VoucherDetail> DeleteAsync(int id)
            //{
            //    return this.repo.DeleteAsync(id);
            //}

            //public Task<List<VoucherDetail>> DeleteRangeAsync(List<int> ids)
            //{
            //    return this.repo.DeleteRangeAsync(ids);
            //}

            //public IQueryable<VoucherDetail> Get()
            //{
            //    return this.repo.Get();
            //}

            //public IQueryable<VoucherDetail> GetAll()
            //{
            //    return this.repo.GetAll();
            //}

            //public Task<VoucherDetail> GetAsync(int id)
            //{
            //    return this.repo.GetAsync(id);
            //}

            //public Task<VoucherDetail> InactivateAsync(int id)
            //{
            //    return this.repo.InactivateAsync(id);
            //}

            //public Task<List<VoucherDetail>> InactivateRangeAsync(List<int> ids)
            //{
            //    return this.repo.InactivateRangeAsync(ids);
            //}

            //public Task<VoucherDetail> UpdateAsync(VoucherDetail entity)
            //{
            //    return this.repo.UpdateAsync(entity);
            //}

            //public Task<List<VoucherDetail>> UpdateRangeAsync(List<VoucherDetail> entities)
            //{
            //    return this.repo.UpdateRangeAsync(entities);
            //}

        }
    }
}
