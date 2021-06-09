using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace SignalRBlazorRedis.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IConfiguration _configuration;

        public ChatHub(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendToAll(string message)
            => await Clients.All.SendAsync(
                "ShowMessageInClient"
                , $"{message} - Send By Server : {_configuration.GetValue<string>("ServerName")}");
    }
}