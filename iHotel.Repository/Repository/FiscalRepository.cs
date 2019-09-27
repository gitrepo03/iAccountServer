using System;
using System.Collections.Generic;
using iHotel.Entity.Accounting;
using System.Text;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.SignalRHub;

namespace iHotel.Repository.Repository
{
    public class FiscalRepository : Repository<FiscalYear>
    {
        public FiscalRepository(IHotelDbContext context, AppHub<FiscalYear> orgHub) : base(context, orgHub)
        {
        }
    }
}
