using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Entity.Helper
{
    public class HubResponse<T>
    {
        public string HubDataState { get; set; }
        public List<T> Data { get; set; }
    }
}
