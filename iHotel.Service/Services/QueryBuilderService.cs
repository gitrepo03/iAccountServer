using iHotel.Entity.Common;
using iHotel.Repository.RepoInterface;
using iHotel.Repository.Repository;
using iHotel.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHotel.Service.Services
{
    public class QueryBuilderService<T> : IQueryBuilderService<T> where T : BaseEntity
    {
        private readonly IReadRepository<WriteActivityLog> _walRepo;
        private readonly OrganizationRepository _orgRepo;
        public QueryBuilderService(IReadRepository<WriteActivityLog> walRepo, OrganizationRepository orgRepo)
        {
            _walRepo = walRepo;
            _orgRepo = orgRepo;
        }

        public IQueryable walOrgJoinQuery(IQueryable<T> source)
        {
            return from s in source
                   join w in _walRepo.GetAll()
                   on s.AudId equals w.AudId
                   join o in _orgRepo.GetAll()
                   on s.Organization equals o.Id
                   select new
                   {
                       source = s,
                       wal = w,
                       org = o
                   };
        }
    }
}
