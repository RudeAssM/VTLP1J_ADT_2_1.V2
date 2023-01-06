using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace VTLP1J_ADT_2022_23_1.V2.Endpoint.Services
{
    public class SignalHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected",Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Disconnected",Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }

}