using iHotel.Entity.Admin;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Common
{
    public class BaseEntity : EntityBase
    {
        public string AudId { get; set; }
        public int? Organization { get; set; }
        public string User { get; set; }

        public virtual Organization OrganizationNavigation { get; set; }
        public ApplicationUser UserNavigation { get; set; }
    }
}
