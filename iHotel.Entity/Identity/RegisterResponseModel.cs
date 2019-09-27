using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Identity
{
    public class RegisterResponseModel
    {
        public IdentityResult NewUserResult { get; set; }
        public IdentityResult RoleAddResult { get; set; }
        public bool SentAccVerfCodeSucceed { get; set; }
    }
}
