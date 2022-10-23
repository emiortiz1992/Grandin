using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TPI_UNLAM_Backend.Hubs;

namespace TPI_UNLAM_Backend.Controllers.v1
{
    
    [ApiController]
    public class LlamadaController : ControllerBase
    {
        private IHubContext<MessageHub> _hubContext;

        public LlamadaController (IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        
        [HttpGet("api/v1/llamadaSaliente")]
        public async Task<IActionResult> startHubConnection(string message)
        {
            await _hubContext.Clients.All.SendAsync("sendMessage", message);
            return Ok();
        }

        [HttpPost("api/v1/llamadaSaliente")]
        public async Task<IActionResult> startHubConnection2(string message)
        {
            await _hubContext.Clients.All.SendAsync("sendMessage", message);
            return Ok();
        }

    }
}
