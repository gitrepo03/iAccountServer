using iHotel.Entity.Accounting;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using iHotel.Repository.SignalRHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Repository
{
    public class LedgerRefRepository : Repository<LedgerRef>
    {
        public LedgerRefRepository(IHotelDbContext context, AppHub<LedgerRef> orgHub) : base(context, orgHub)
        {
        }
    }
}
