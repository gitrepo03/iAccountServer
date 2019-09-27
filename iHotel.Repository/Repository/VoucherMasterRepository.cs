using iHotel.Entity.Accounting;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.SignalRHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Repository
{
    public class VoucherMasterRepository : Repository<VoucherMaster>
    {
        public VoucherMasterRepository(IHotelDbContext context, AppHub<VoucherMaster> orgHub) : base(context, orgHub)
        {
        }
    }
}
