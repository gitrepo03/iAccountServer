using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Accounting
{
    public partial class VoucherType: BaseEntity
    {
        public VoucherType()
        {
            VoucherMasters = new HashSet<VoucherMaster>();
        }
        
        public string VoucherCode { get; set; }
        public string VoucherName { get; set; }
        
        public virtual ICollection<VoucherMaster> VoucherMasters { get; set; }
    }
}
