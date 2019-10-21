using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Accounting
{
    public partial class AccountRef: BaseEntity
    {
        public AccountRef()
        {
            LedgerRefs = new HashSet<LedgerRef>();
            AccountRefs = new HashSet<AccountRef>();
        }
        
        public string Fiscal { get; set; }
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
        public int NodeLevel { get; set; }
        public int Parent { get; set; }
        public string Tb { get; set; }
        public string Pl { get; set; }
        public string Bs { get; set; }
        public bool IsDefaultGroup { get; set; }
        public bool HasSubLedger { get; set; }

        public virtual FiscalYear FiscalNavigation { get; set; }
        public virtual AccountRef AccountRefNavigation { get; set; }

        public virtual ICollection<LedgerRef> LedgerRefs { get; set; }
        public virtual ICollection<AccountRef> AccountRefs { get; set; }
    }

    public class AccountRef_R: AccountRef
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
