using iHotel.Entity.Accounting;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using iHotel.Repository.SignalRHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Repository
{
    public class VoucherDetailRepository : Repository<VoucherDetail>
    {
        public VoucherDetailRepository(IHotelDbContext context, AppHub<VoucherDetail> orgHub) : base(context, orgHub)
        {
        }
    }
}
