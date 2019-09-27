using iHotel.Entity.Accounting;
using iHotel.Entity.Admin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            AccountRefs = new HashSet<AccountRef>();
            Fiscals = new HashSet<FiscalYear>();
            LedgerRefs = new HashSet<LedgerRef>();
            VoucherDetails = new HashSet<VoucherDetail>();
            VoucherMasters = new HashSet<VoucherMaster>();
            VoucherTypes = new HashSet<VoucherType>();
            Organizations = new HashSet<UsersOrgs>();
        }

        public string FullName { get; set; }
        public int Organization { get; set; }

        //public Organization OrganizationNavigation { get; set; }

        public virtual ICollection<AccountRef> AccountRefs { get; set; }
        public virtual ICollection<FiscalYear> Fiscals { get; set; }
        public virtual ICollection<LedgerRef> LedgerRefs { get; set; }
        public virtual ICollection<VoucherDetail> VoucherDetails { get; set; }
        public virtual ICollection<VoucherMaster> VoucherMasters { get; set; }
        public virtual ICollection<VoucherType> VoucherTypes { get; set; }
        public virtual ICollection<UsersOrgs> Organizations { get; set; }

    }
}
