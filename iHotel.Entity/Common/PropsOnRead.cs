using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Common
{
    public abstract class PropsOnRead
    {
        public string C_User { get; set; }
        public string C_On_BS { get; set; }
        public string C_On_AD { get; set; }
        public string U_User { get; set; }
        public string U_On_BS { get; set; }
        public string U_On_AD { get; set; }
    }
}
