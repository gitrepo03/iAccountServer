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
    public class LedgerRefService : CoreService<LedgerRef>, ILedgerRefService
    {
        private readonly IReadRepository<WriteActivityLog> _walRepo;
        public LedgerRefService(IRepository<LedgerRef> repo, IReadRepository<WriteActivityLog> walRepo) : base(repo)
        {
            _walRepo = walRepo;
        }

        IQueryable<LedgerRef_R> ICoreService_R<LedgerRef_R>.GetAll()
        {
            return createReadDataAsync(this.GetAll());
        }

        IQueryable<LedgerRef_R> ICoreService_R<LedgerRef_R>.GetAllOfOrg()
        {
            return createReadDataAsync(this.GetAllOfOrg());
        }

        IQueryable<LedgerRef_R> ICoreService_R<LedgerRef_R>.GetById(int id)
        {
            return createReadDataAsync(this.GetById(id));
        }

        private IQueryable<LedgerRef_R> createReadDataAsync(IQueryable<LedgerRef> source)
        {
            return from lr in source
                    join w in _walRepo.GetAll()
                    on lr.AudId equals w.AudId
                    into lj_w
                    from w in lj_w.Where(w => w.ActivityTable == "LedgerRef").DefaultIfEmpty()
                    select new LedgerRef_R()
                    {
                        Id = lr.Id,
                        LedgerCode = lr.LedgerCode,
                        LedgerName = lr.LedgerName,
                        IsDefault = lr.IsDefault,
                        BalanceType = lr.BalanceType,
                        IsActive = lr.IsActive,
                        AudId = lr.AudId,
                        Organization = lr.Organization,
                        User = lr.User,
                        FiscalYear = lr.FiscalYear,
                        GroupCode = lr.GroupCode,
                        OrgName = lr.OrganizationNavigation.OrgName,
                        C_User = w.User,
                        C_On_AD = w.DateAd.GetValueOrDefault().ToShortDateString(),
                        C_On_BS = w.DateBs
                    };
        }

        //private readonly IRepository<LedgerRef> repo;

        //public LedgerRefService(IRepository<LedgerRef> repo)
        //{
        //    this.repo = repo;
        //}

        //public Task<int> CountAsync()
        //{
        //    return this.repo.CountAsync();
        //}

        //public Task<LedgerRef> CreateAsync(LedgerRef entity)
        //{
        //    return this.repo.CreateAsync(entity);
        //}

        //public Task<List<LedgerRef>> CreateRangeAsync(List<LedgerRef> entities)
        //{
        //    return this.repo.CreateRangeAsync(entities);
        //}

        //public Task<LedgerRef> DeleteAsync(int id)
        //{
        //    return this.repo.DeleteAsync(id);
        //}

        //public Task<List<LedgerRef>> DeleteRangeAsync(List<int> ids)
        //{
        //    return this.repo.DeleteRangeAsync(ids);
        //}

        //public IQueryable<LedgerRef> Get()
        //{
        //    return this.repo.Get();
        //}

        //public IQueryable<LedgerRef> GetAll()
        //{
        //    return this.repo.GetAll();
        //}

        //public Task<LedgerRef> GetAsync(int id)
        //{
        //    return this.repo.GetAsync(id);
        //}

        //public Task<LedgerRef> InactivateAsync(int id)
        //{
        //    return this.repo.InactivateAsync(id);
        //}

        //public Task<List<LedgerRef>> InactivateRangeAsync(List<int> ids)
        //{
        //    return this.repo.InactivateRangeAsync(ids);
        //}

        //public Task<LedgerRef> UpdateAsync(LedgerRef entity)
        //{
        //    return this.repo.UpdateAsync(entity);
        //}

        //public Task<List<LedgerRef>> UpdateRangeAsync(List<LedgerRef> entities)
        //{
        //    return this.repo.UpdateRangeAsync(entities);
        //}

    }
}
