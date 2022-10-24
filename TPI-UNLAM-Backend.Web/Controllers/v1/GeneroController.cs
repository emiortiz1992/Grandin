using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.EF;
using TPI_UNLAM_Backend.Servicios;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Controllers.v1
{
    [ApiController]
    public class GeneroController : Controller
    {
        private readonly IGeneroServicio _generoServicio;

        public GeneroController(IGeneroServicio generoServicio)
        {
            _generoServicio = generoServicio;
        }

        [HttpGet("api/v1/getAllGeneros")]
        public ActionResult<List<Genero>> GetAllGeneros()
        {
            return _generoServicio.getAllGeneros();
        }
    }
}
