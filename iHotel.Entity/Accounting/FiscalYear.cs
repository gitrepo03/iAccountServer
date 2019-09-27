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
}
