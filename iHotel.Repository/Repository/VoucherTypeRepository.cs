using iHotel.Entity.Accounting;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using iHotel.Repository.SignalRHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Repository
{
    public class VoucherTypeRepository : Repository<VoucherType>
    {
        public VoucherTypeRepository(IHotelDbContext context, AppHub<VoucherType> orgHub) : base(context, orgHub)
        {
        }
    }
}
