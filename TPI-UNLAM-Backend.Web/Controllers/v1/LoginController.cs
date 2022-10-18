using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Controllers.v1
{
    [ApiController]
    public class LoginController : Controller
    {

        private readonly IUsuarioServicio _usuarioServicio;

        public LoginController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }


        [HttpPost("api/v1/auth")]
        public UsuarioDto Login([FromBody] LoginDto loginDto)
        {
           return _usuarioServicio.Login(loginDto);
        }
    }
}
