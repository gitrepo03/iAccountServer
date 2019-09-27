﻿using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Accounting
{
    public partial class LedgerRef: BaseEntity
    {
        public LedgerRef()
        {
            VoucherDetails = new HashSet<VoucherDetail>();
        }
        
        public string FiscalYear { get; set; }
        public int GroupCode { get; set; }
        public int LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public bool IsDefault { get; set; }
        public string BalanceType { get; set; }

        public virtual AccountRef AccountRef { get; set; }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
    }
}
