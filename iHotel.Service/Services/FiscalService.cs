using iHotel.Entity.Accounting;
using iHotel.Entity.Common;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using iHotel.Repository.Repository;
using iHotel.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Service.Services
{
    //public class FiscalService : CoreService<FiscalYear>, ICoreService_R<FiscalYear_R>
    public class FiscalService : CoreService<FiscalYear>, IFiscalService
    {
        private readonly IReadRepository<WriteActivityLog> _walRepo;
        public FiscalService(IRepository<FiscalYear> repo, IReadRepository<WriteActivityLog> walRepo) : base(repo){
            _walRepo = walRepo;
        }

        IQueryable<FiscalYear_R> ICoreService_R<FiscalYear_R>.GetAll()
        {
            return createReadDataAsync(this.GetAll());
        }

        //IQueryable<FiscalYear_R> ICoreService_R<FiscalYear_R>.GetAllActive()
        //{
        //    return createReadDataAsync(this.GetAllActive());
        //}

        IQueryable<FiscalYear_R> ICoreService_R<FiscalYear_R>.GetAllOfOrg()
        {
            return createReadDataAsync(this.GetAllOfOrg());
        }

        //IQueryable<FiscalYear_R> ICoreService_R<FiscalYear_R>.GetAllActiveOfOrg()
        //{
        //    return createReadDataAsync(this.GetAllActiveOfOrg());
        //}

        IQueryable<FiscalYear_R> ICoreService_R<FiscalYear_R>.GetById(int id)
        {
            return createReadDataAsync(this.GetById(id));
        }

        private IQueryable<FiscalYear_R> createReadDataAsync(IQueryable<FiscalYear> source)
        {

            return (from f in source
                    join w in _walRepo.GetAll()
                    on f.AudId equals w.AudId
                    where w.ActivityTable == "FiscalYear"
                    select new FiscalYear_R()
                    {
                        Id = f.Id,
                        IsActive = f.IsActive,
                        AudId = f.AudId,
                        Organization = f.Organization,
                        OrgName = f.OrganizationNavigation.OrgName,
                        User = f.User,
                        Fiscal = f.Fiscal,
                        DateBeginNepali = f.DateBeginNepali,
                        DateEndNepali = f.DateEndNepali,
                        DateBeginEnglish = f.DateBeginEnglish,
                        DateEndEnglish = f.DateEndEnglish,
                        C_User = w.User,
                        C_On_AD = w.DateAd.GetValueOrDefault().ToShortDateString(),
                        C_On_BS = w.DateBs,
                    });
        }

        //public Task<int> CountAsync()
        //{
        //    return this.repo.CountAsync();
        //}

        //public Task<FiscalYear> CreateAsync(FiscalYear entity)
        //{
        //    return this.repo.CreateAsync(entity);
        //}

        //public Task<List<FiscalYear>> CreateRangeAsync(List<FiscalYear> entities)
        //{
        //    return this.repo.CreateRangeAsync(entities);
        //}

        //public Task<FiscalYear> DeleteAsync(int id)
        //{
        //    return this.repo.DeleteAsync(id);
        //}

        //public Task<List<FiscalYear>> DeleteRangeAsync(List<int> ids)
        //{
        //    return this.repo.DeleteRangeAsync(ids);
        //}

        //public IQueryable<FiscalYear> Get()
        //{
        //    return this.repo.Get();
        //}

        //public IQueryable<FiscalYear> GetAll()
        //{
        //    return this.repo.GetAll();
        //}

        //public IQueryable<FiscalYear> GetById(int id)
        //{
        //    return this.repo.GetById(id);
        //}

        //public Task<FiscalYear> InactivateAsync(int id)
        //{
        //    return this.repo.InactivateAsync(id);
        //}

        //public Task<List<FiscalYear>> InactivateRangeAsync(List<int> ids)
        //{
        //    return this.repo.InactivateRangeAsync(ids);
        //}

        //public Task<FiscalYear> UpdateAsync(FiscalYear entity)
        //{
        //    return this.repo.UpdateAsync(entity);
        //}

        //public Task<List<FiscalYear>> UpdateRangeAsync(List<FiscalYear> entities)
        //{
        //    return this.repo.UpdateRangeAsync(entities);
        //}


    }
}
