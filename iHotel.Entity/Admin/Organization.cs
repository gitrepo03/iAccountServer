using iHotel.Entity.Accounting;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Admin
{
    public partial class Organization: EntityBase
    {
        public Organization()
        {
            AccountRefs = new HashSet<AccountRef>();
            ChangeLogs = new HashSet<ChangeLog>();
            FiscalYears = new HashSet<FiscalYear>();
            LedgerRefs = new HashSet<LedgerRef>();
            OrganizationImagePaths = new HashSet<OrganizationImagePath>();
            Users = new HashSet<UsersOrgs>();
            VoucherDetails = new HashSet<VoucherDetail>();
            VoucherMasters = new HashSet<VoucherMaster>();
            VoucherTypes = new HashSet<VoucherType>();
            WriteActivityLogs = new HashSet<WriteActivityLog>();
            //Users = new HashSet<ApplicationUser>();
        }
        
        public string OrgName { get; set; }
        public string OrgNameNp { get; set; }
        public string PanNo { get; set; }
        //public string FiscalYear { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime? EstablishedDateAd { get; set; }
        public string EstablishedDateBs { get; set; }
        public string Logo { get; set; }
        public string Quote { get; set; }
        public string OrgCode { get; set; }

        public virtual ICollection<AccountRef> AccountRefs { get; set; }
        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }
        public virtual ICollection<FiscalYear> FiscalYears { get; set; }
        public virtual ICollection<LedgerRef> LedgerRefs { get; set; }
        public virtual ICollection<OrganizationImagePath> OrganizationImagePaths { get; set; }
        public virtual ICollection<UsersOrgs> Users { get; set; }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
        public virtual ICollection<VoucherMaster> VoucherMasters { get; set; }
        public virtual ICollection<VoucherType> VoucherTypes { get; set; }
        public virtual ICollection<WriteActivityLog> WriteActivityLogs { get; set; }
        //public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
