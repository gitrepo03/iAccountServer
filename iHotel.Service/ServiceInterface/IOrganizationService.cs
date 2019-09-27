using iHotel.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Service.ServiceInterface
{
    public interface IOrganizationService : ICoreService<Organization>
    {
        //List<Organization> getPagedOrganizationDetails(Pagination pagination, bool withDeactivated = false);
    }
}
