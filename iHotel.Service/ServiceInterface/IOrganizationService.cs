using iHotel.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHotel.Service.ServiceInterface
{
    public interface IOrganizationService : ICoreService<Organization>
    {
        //Get all.
        IQueryable<Organization> GetAll();
        //Get a single data with id.
        IQueryable<Organization> GetById(int id);
        //List<Organization> getPagedOrganizationDetails(Pagination pagination, bool withDeactivated = false);
    }
}
