using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Identity
{
    public class PasswordResetRequest
    {
        public string email { get; set; }
        public string user { get; set; }
        public string token { get; set; }
    }
}
