using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Controllers.v1
{
    [ApiController]
    public class RegistroController : Controller
    {

        private readonly IUsuarioServicio _usuarioServicio;

        public RegistroController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("api/v1/agregarUsuario")]
        public void agregarUsuario([FromBody] UsuarioDto usuario)
        {
            _usuarioServicio.AgregarUsuario(usuario);
        }


    }
}
