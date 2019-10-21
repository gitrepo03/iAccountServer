using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Accounting
{
    public partial class VoucherMaster: BaseEntity
    {
        public VoucherMaster()
        {
            VoucherDetails = new HashSet<VoucherDetail>();
        }
        
        public string FiscalYear { get; set; }
        public int VoucherNumber { get; set; }
        public string VoucherCode { get; set; }
        public DateTime DateEnglish { get; set; }
        public string DateNepali { get; set; }
        public decimal Total { get; set; }
        public string InWords { get; set; }
        public int UserCode { get; set; }

        public virtual FiscalYear FiscalYearNavigation { get; set; }
        public virtual VoucherType VoucherCodeNavigation { get; set; }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
    }

    public class VoucherMaster_R: VoucherMaster
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
