using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Identity
{
    public class UserModel: BaseAuth
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int Organization { get; set; }
    }
}
