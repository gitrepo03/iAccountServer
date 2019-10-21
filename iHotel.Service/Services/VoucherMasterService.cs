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
    public class VoucherMasterService : CoreService<VoucherMaster>, IVoucherMasterService
    {
        private readonly IReadRepository<WriteActivityLog> _walRepo;
        public VoucherMasterService(IRepository<VoucherMaster> repo, IReadRepository<WriteActivityLog> walRepo) : base(repo)
        {
            _walRepo = walRepo;
        }

        IQueryable<VoucherMaster_R> ICoreService_R<VoucherMaster_R>.GetAll()
        {
            return createReadDataAsync(this.GetAll());
        }

        IQueryable<VoucherMaster_R> ICoreService_R<VoucherMaster_R>.GetAllOfOrg()
        {
            return createReadDataAsync(this.GetAllOfOrg());
        }

        IQueryable<VoucherMaster_R> ICoreService_R<VoucherMaster_R>.GetById(int id)
        {
            return createReadDataAsync(this.GetById(id));
        }

        private IQueryable<VoucherMaster_R> createReadDataAsync(IQueryable<VoucherMaster> source)
        {

            return from vm in source
                    join w in _walRepo.GetAll()
                    on vm.AudId equals w.AudId
                    into lj_w
                    from w in lj_w.Where(w => w.ActivityTable == "VoucherMaster").DefaultIfEmpty()
                    select new VoucherMaster_R()
                    {
                        
                        DateEnglish = vm.DateEnglish,
                        DateNepali = vm.DateNepali,
                        Total = vm.Total,
                        InWords = vm.InWords,
                        UserCode = vm.UserCode,
                        Id = vm.Id,
                        AudId = vm.AudId,
                        VoucherNumber = vm.VoucherNumber,
                        VoucherCode = vm.VoucherCode,
                        Organization = vm.Organization,
                        User = vm.User,
                        FiscalYear = vm.FiscalYear,
                        IsActive = vm.IsActive,
                        OrgName = vm.OrganizationNavigation.OrgName,
                        C_User = w.User,
                        C_On_AD = w.DateAd.GetValueOrDefault().ToShortDateString(),
                        C_On_BS = w.DateBs
                    };
        }

        //private readonly IRepository<VoucherMaster> repo;

        //public VoucherMasterService(IRepository<VoucherMaster> repo)
        //{
        //    this.repo = repo;
        //}

        //public Task<int> CountAsync()
        //{
        //    return this.repo.CountAsync();
        //}

        //public Task<VoucherMaster> CreateAsync(VoucherMaster entity)
        //{
        //    return this.repo.CreateAsync(entity);
        //}

        //public Task<List<VoucherMaster>> CreateRangeAsync(List<VoucherMaster> entities)
        //{
        //    return this.repo.CreateRangeAsync(entities);
        //}

        //public Task<VoucherMaster> DeleteAsync(int id)
        //{
        //    return this.repo.DeleteAsync(id);
        //}

        //public Task<List<VoucherMaster>> DeleteRangeAsync(List<int> ids)
        //{
        //    return this.repo.DeleteRangeAsync(ids);
        //}

        //public IQueryable<VoucherMaster> Get()
        //{
        //    return this.repo.Get();
        //}

        //public IQueryable<VoucherMaster> GetAll()
        //{
        //    return this.repo.GetAll();
        //}

        //public Task<VoucherMaster> GetAsync(int id)
        //{
        //    return this.repo.GetAsync(id);
        //}

        //public Task<VoucherMaster> InactivateAsync(int id)
        //{
        //    return this.repo.InactivateAsync(id);
        //}

        //public Task<List<VoucherMaster>> InactivateRangeAsync(List<int> ids)
        //{
        //    return this.repo.InactivateRangeAsync(ids);
        //}

        //public Task<VoucherMaster> UpdateAsync(VoucherMaster entity)
        //{
        //    return this.repo.UpdateAsync(entity);
        //}

        //public Task<List<VoucherMaster>> UpdateRangeAsync(List<VoucherMaster> entities)
        //{
        //    return this.repo.UpdateRangeAsync(entities);
        //}

    }
}
