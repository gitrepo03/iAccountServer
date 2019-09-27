using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Accounting
{
    public partial class VoucherDetail: BaseEntity
    {
        public string FiscalYear { get; set; }
        public int VoucherNumber { get; set; }
        public string VoucherCode { get; set; }
        public int SerialNumber { get; set; }
        public int LedgerCode { get; set; }
        public string BalanceType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public virtual LedgerRef LedgerCodeNavigation { get; set; }
        public virtual VoucherMaster VoucherMasters { get; set; }
    }
}
