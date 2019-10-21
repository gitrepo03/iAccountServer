using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Accounting
{
    public partial class FiscalYear: BaseEntity
    {
        public FiscalYear()
        {
            AccountRef = new HashSet<AccountRef>();
            VoucherMasters = new HashSet<VoucherMaster>();
        }
        
        public string Fiscal { get; set; }
        public string DateBeginNepali { get; set; }
        public string DateEndNepali { get; set; }
        public DateTime DateBeginEnglish { get; set; }
        public DateTime DateEndEnglish { get; set; }
        
        public virtual ICollection<AccountRef> AccountRef { get; set; }
        public virtual ICollection<VoucherMaster> VoucherMasters { get; set; }
    }

    public partial class FiscalYear_R: FiscalYear
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
