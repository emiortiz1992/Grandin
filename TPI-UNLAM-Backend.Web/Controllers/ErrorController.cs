using System;
using System.Net;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_UNLAM_Backend.Exceptions;

namespace TPI_UNLAM_Backend.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IHostingEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;

            if (ex is NotFoundException) { if (ex.Message == "") return NotFound(); return NotFound(ex.Message);}
            if (ex is BadRequestException) { if (ex.Message == "") return BadRequest(); return BadRequest(ex.Message); }

            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = ex.GetType().Name,
                Detail = ex.StackTrace,
            };

            return StatusCode((int)HttpStatusCode.InternalServerError, new
            {
                message = "Lo siento, ha ocurrido un error inesperado.",
                items = problemDetails
            });
        }

        [Route("/error")]
        public ActionResult Error([FromServices] IHostingEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;

            if (ex is NotFoundException) { if (ex.Message == "") return NotFound(); return NotFound(ex.Message); }
            if (ex is BadRequestException) { if (ex.Message == "") return BadRequest(); return BadRequest(ex.Message); }

            var isDev = webHostEnvironment.IsDevelopment();
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = feature?.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : "An error occurred.",
                Detail = isDev ? ex.StackTrace : null,
            };

            //_logErrorBusiness.Logmethodname, $"{feature.Error} + , Route:  {feature.Path}");

            return StatusCode((int)HttpStatusCode.InternalServerError, new
                {
                    message = "Lo siento, ha ocurrido un error inesperado.",
                    items = problemDetails
                });
        }
    }
}

