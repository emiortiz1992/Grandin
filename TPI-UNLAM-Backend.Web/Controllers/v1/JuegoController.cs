using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Controllers.v1
{
    [ApiController]
    public class JuegoController : Controller
    {

        private readonly IJuegoServicio _juegoServicio;

        public JuegoController(IJuegoServicio juegoServicio)
        {
            _juegoServicio = juegoServicio;
        }

        [HttpGet("api/v1/getAllJuegos")]
        public ActionResult<List<Juego>> GetAllJuegos()
        {
            return _juegoServicio.getAllJuegos();
        }

        [HttpGet("api/v1/getAllColores")]
        public ActionResult<List<Colore>> GetAllColores()
        {
            return _juegoServicio.getAllColores();
        }

        [HttpPost("api/v1/ValidarCamposIguales")]
        public bool ValidarCamposIguales(string campo1, string campo2)
        {
            return _juegoServicio.validarStringIguales(campo1, campo2);
        }

        [HttpGet("api/v1/getNumerosDesordenados")]
        public ActionResult<List<int>> GetNumerosDesordenados() 
        {
            return _juegoServicio.getNumerosDesordenados();
        }
        
        [HttpPost("api/v1/VerificarNumerosOrdenados")]
        public bool VerificiarNumerosOrdenados(List<int> numeros)
        {
            return _juegoServicio.verificarNumerosOrdenados(numeros);
        }

        [HttpPost("api/v1/FinalizarJuego")]
        public void FinalizarJuego([FromBody]ResultadoJuegoDto juego)
        {
            _juegoServicio.FinalizarJuego(juego);
        }

        [HttpGet("api/v1/getImagenesPorJuego")]
        public ActionResult<string> GetImagenPorJuego(string codigo)
        {
            return _juegoServicio.getImagenPorJuego(codigo);
        }

        [HttpGet("api/v1/getJuegoByIds")]
        public ActionResult<Juego> getJuegoById(int idJuego)
        {
            return _juegoServicio.getJuegoById(idJuego);
        }

    }
}
