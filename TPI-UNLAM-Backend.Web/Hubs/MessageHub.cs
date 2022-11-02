using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TPI_UNLAM_Backend.Hubs
{
    public class MessageHub : Hub
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user, message);
            
        }
        
        public async Task AgregarAGrupo(string grupo)
        {
            await Groups.AddToGroupAsync(GetConnectionId(), grupo);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        //public async Task SendToUser(string user, string receiverConnectionId, string message)
        //{
        //    await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage",user, message);
        //}
    }
}
