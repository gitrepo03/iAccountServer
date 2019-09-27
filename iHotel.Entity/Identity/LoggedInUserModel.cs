using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Identity
{
    public class LoggedInUserModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Organization { get; set; }
    }
}
