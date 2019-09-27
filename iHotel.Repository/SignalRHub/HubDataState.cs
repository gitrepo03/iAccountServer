using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.SignalRHub
{
    public class HubDataState
    {
        public static readonly string Edited = "Data.State.Edited";
        public static readonly string Added = "Data.State.Added";
        public static readonly string Removed = "Data.State.Removed";
    }
}
