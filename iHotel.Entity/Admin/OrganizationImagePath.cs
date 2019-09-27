using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using System;
using System.Collections.Generic;

namespace iHotel.Entity.Admin
{
    public partial class OrganizationImagePath: BaseEntity
    {
        public string UserNavigationId { get; set; }
        public string PathTitle { get; set; }
        public string ImgPath { get; set; }
    }
}
