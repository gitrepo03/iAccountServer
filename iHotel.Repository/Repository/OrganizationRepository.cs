using iHotel.Entity.Admin;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.SignalRHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Repository
{
    public class OrganizationRepository : Repository<Organization>
    {
        public OrganizationRepository(IHotelDbContext context, AppHub<Organization> orgHub) : base(context, orgHub)
        {
        }
    }
}
