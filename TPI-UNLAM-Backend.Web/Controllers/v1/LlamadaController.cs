using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;
using TPI_UNLAM_Backend.Hubs;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Controllers.v1
{
    
    [ApiController]
    public class LlamadaController : ControllerBase
    {
        private IHubContext<MessageHub> _hubContext;
        private ILlamadaServicio _llamadaServicio;

        public LlamadaController (IHubContext<MessageHub> hubContext, ILlamadaServicio llamadaServicio)
        {
            _hubContext = hubContext;
            _llamadaServicio = llamadaServicio;
        }

        
        //[HttpGet("api/v1/llamadaSaliente")]
        //public async Task<IActionResult> startHubConnection(string message)
        //{
        //    await _hubContext.Clients.All.SendAsync("sendMessage", message);
        //    return Ok();
        //}

        [HttpPost("api/v1/llamadaSaliente")]
        public async Task<IActionResult> startHubConnection2([FromBody] MensajeLlamadaDto llamadaDto)
        {
            await _hubContext.Clients.Group(llamadaDto.ReceptorId).SendAsync("sendMessage", llamadaDto);
            return Ok();
        }

        [HttpPost("api/v1/guardarLlamada")]
        public void GuardarLlamada([FromBody] LlamadaDto llamada)
        {
            _llamadaServicio.GuardarLlamada(llamada);
        }

        [HttpGet("api/v1/obtenerLlamadaActual")]
        public LlamadaDto obtenerLlamadaActual()
        {
            return _llamadaServicio.obtenerLlamadaActual();
        }

     

    }
}
