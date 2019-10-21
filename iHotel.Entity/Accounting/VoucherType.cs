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

    public class VoucherType_R: VoucherType
    {
        public string OrgName { get; set; }
        public string C_User { get; set; }
        public string C_On_BS { get; set; }
        public string C_On_AD { get; set; }
        public string U_User { get; set; }
        public string U_On_BS { get; set; }
        public string U_On_AD { get; set; }
    }
}
