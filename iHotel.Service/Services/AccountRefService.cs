using iHotel.Entity.Accounting;
using iHotel.Entity.Common;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.Helper;
using iHotel.Repository.RepoInterface;
using iHotel.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Service.Services
{
    public class AccountRefService : CoreService<AccountRef>, IAccountRefService
    {
        private readonly IReadRepository<WriteActivityLog> _walRepo;
        public AccountRefService(IRepository<AccountRef> repo, IReadRepository<WriteActivityLog> walRepo) : base(repo)
        {
            _walRepo = walRepo;
        }

        IQueryable<AccountRef_R> ICoreService_R<AccountRef_R>.GetAll()
        {
            return createReadDataAsync(this.GetAll());
        }

        IQueryable<AccountRef_R> ICoreService_R<AccountRef_R>.GetAllOfOrg()
        {
            return createReadDataAsync(this.GetAllOfOrg());
        }

        IQueryable<AccountRef_R> ICoreService_R<AccountRef_R>.GetById(int id)
        {
            return createReadDataAsync(this.GetById(id));
        }

        private IQueryable<AccountRef_R> createReadDataAsync(IQueryable<AccountRef> source)
        {

            return from ar in source
                join w in _walRepo.GetAll()
                on ar.AudId equals w.AudId
                into lj_w
                from w in lj_w.Where(w => w.ActivityTable == "AccountRef").DefaultIfEmpty()
                select new AccountRef_R()
                {
                    Id = ar.Id,
                    IsActive = ar.IsActive,
                    AudId = ar.AudId,
                    Organization = ar.Organization,
                    User = ar.User,
                    Fiscal = ar.Fiscal,
                    GroupCode = ar.GroupCode,
                    GroupName = ar.GroupName,
                    NodeLevel = ar.NodeLevel,
                    Parent = ar.Parent,
                    Tb = ar.Tb,
                    Pl = ar.Pl,
                    Bs = ar.Bs,
                    IsDefaultGroup = ar.IsDefaultGroup,
                    HasSubLedger = ar.HasSubLedger,
                    OrgName = ar.OrganizationNavigation.OrgName,
                    C_User = w.User,
                    C_On_AD = w.DateAd.GetValueOrDefault().ToShortDateString(),
                    C_On_BS = w.DateBs
                };

            //var query = from ar in source
            //        join w in _db.WriteActivityLogs
            //        on ar.AudId equals w.AudId
            //        join o in _db.Organizations
            //        on ar.Organization equals o.Id
            //        where w.ActivityTable == "FiscalYear"
            //        select new {
            //            ar,
            //            arr = new
            //            {
            //                o.OrgName,
            //                w.ActivityBy,
            //                dateAd = w.DateAd.GetValueOrDefault().ToShortDateString(),
            //                w.DateBs
            //            }
            //        };

            //IQueryable<AccountRef_R> accRef_R = (IQueryable<AccountRef_R>)query.Select(q => q.ar);
            //var accRef_Rr = JsLikeExtensions.sprade(
            //    new List<object>() {
            //        query.Select(q => q.ar)
            //    },
            //    accRef_R
            //);



        }

        //private readonly IRepository<AccountRef> repo;

        //public AccountRefService(IRepository<AccountRef> repo)
        //{
        //    this.repo = repo;
        //}

        //public Task<int> CountAsync()
        //{
        //    return this.repo.CountAsync();
        //}

        //public Task<AccountRef> CreateAsync(AccountRef entity)
        //{
        //    return this.repo.CreateAsync(entity);
        //}

        //public Task<List<AccountRef>> CreateRangeAsync(List<AccountRef> entities)
        //{
        //    return this.repo.CreateRangeAsync(entities);
        //}

        //public Task<AccountRef> DeleteAsync(int id)
        //{
        //    return this.repo.DeleteAsync(id);
        //}

        //public Task<List<AccountRef>> DeleteRangeAsync(List<int> ids)
        //{
        //    return this.repo.DeleteRangeAsync(ids);
        //}

        //public IQueryable<AccountRef> Get()
        //{
        //    return this.repo.Get();
        //}

        //public IQueryable<AccountRef> GetAll()
        //{
        //    return this.repo.GetAll();
        //}

        //public Task<AccountRef> GetAsync(int id)
        //{
        //    return this.repo.GetById(id);
        //}

        //public Task<AccountRef> InactivateAsync(int id)
        //{
        //    return this.repo.InactivateAsync(id);
        //}

        //public Task<List<AccountRef>> InactivateRangeAsync(List<int> ids)
        //{
        //    return this.repo.InactivateRangeAsync(ids);
        //}

        //public Task<AccountRef> UpdateAsync(AccountRef entity)
        //{
        //    return this.repo.UpdateAsync(entity);
        //}

        //public Task<List<AccountRef>> UpdateRangeAsync(List<AccountRef> entities)
        //{
        //    return this.repo.UpdateRangeAsync(entities);
        //}

    }
}
