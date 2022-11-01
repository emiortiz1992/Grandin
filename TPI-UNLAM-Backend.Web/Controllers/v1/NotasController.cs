using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Controllers.v1
{
    [ApiController]
    public class NotasController : Controller
    {

        private readonly INotasServicio _notasServicio;

        public NotasController(INotasServicio notasServicio)
        {
            _notasServicio = notasServicio;
        }

        [HttpPost("api/v1/guardarSugerencia")]
        public void guardarSugerencia([FromBody] Sugerencia sugerencia)
        {
            _notasServicio.guardarSugerencia(sugerencia);
        }
        //[HttpPost("api/v1/auth")]
        //public void GuardarNota([FromBody] Nota nota, string codigoLLamado)
        //{
        //    _notasServicio.GuardarNota(nota, codigoLLamado);
        //}
    }
}
