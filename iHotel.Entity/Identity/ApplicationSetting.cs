using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Identity
{
    public class ApplicationSetting
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public string AccountConformationURL { get; set; }
        public string PasswordResetURL { get; set; }
    }
}
