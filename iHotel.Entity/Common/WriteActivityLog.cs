using iHotel.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Common
{
    public class WriteActivityLog
    {
        public int Id { get; set; }
        public int Organization { get; set; }
        public bool ActivityType { get; set; }
        public string ActivityTable { get; set; }
        public string AudId { get; set; }
        public string ActivityBy { get; set; }
        public DateTime? DateAd { get; set; }
        public string DateBs { get; set; }
        public TimeSpan? ActivityTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual Organization OrganizationNavigation { get; set; }
    }
}
