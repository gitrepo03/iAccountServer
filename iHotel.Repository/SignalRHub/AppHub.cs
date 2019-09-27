using iHotel.Entity.Common;
using iHotel.Entity.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Repository.SignalRHub
{
    //[Authorize(Roles = "SuperAdminDeveloper")]
    //[Authorize]
    public class AppHub<T> : Hub
    {
        public async Task Send(string signal, HubResponse<T> resp) => await Clients?.All?.SendAsync(signal, resp);
    }
}
