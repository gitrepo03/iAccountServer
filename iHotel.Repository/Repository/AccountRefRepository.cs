using iHotel.Entity.Accounting;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using iHotel.Repository.SignalRHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Repository
{
    public class AccountRefRepository : Repository<AccountRef>
    {
        public AccountRefRepository(IHotelDbContext context, AppHub<AccountRef> orgHub) : base(context, orgHub)
        {
        }
    }
}
