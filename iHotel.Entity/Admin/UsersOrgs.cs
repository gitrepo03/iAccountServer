using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Admin
{
    public partial class UsersOrgs
    {
        public string User { get; set; }
        public int Organization { get; set; }

        public virtual Organization OrganizationNavigation { get; set; }
        public virtual ApplicationUser UserNavigation { get; set; }
    }
}
