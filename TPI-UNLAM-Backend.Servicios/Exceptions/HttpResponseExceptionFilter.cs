using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using TPI_UNLAM_Backend.Interfaces;

namespace TPI_UNLAM_Backend.Exceptions
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {

        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Value)
                {
                    StatusCode = exception.Status,
                };
                context.ExceptionHandled = true;
            }

            if (context.Exception is NotFoundException) { }

            else if (context.Exception is BadRequestException) { }

            else if (context.Exception is Exception)
            {

                ILogError logErrorBusiness = (ILogError)context.HttpContext.RequestServices.GetService(typeof(ILogError));

                var s = new System.Diagnostics.StackTrace(context.Exception);
                var thisasm = System.Reflection.Assembly.GetExecutingAssembly();
                var methodname = s.GetFrames().Select(f => f.GetMethod()).First(m => m.Module.Assembly == thisasm).Name;

                string Error = $"Route: {context.HttpContext.Request.GetDisplayUrl()} " + Environment.NewLine;
                Error += $"MethodName: {methodname} " + Environment.NewLine;
                if (context.HttpContext.Request.Query != null) Error += $"Query: {JsonConvert.SerializeObject(context.HttpContext.Request.Query)} " + Environment.NewLine;
                string body = string.Empty;

                if (context.HttpContext.Request.Method.ToUpper() == "POST" || context.HttpContext.Request.Method.ToUpper() == "PUT" || context.HttpContext.Request.Method.ToUpper() == "PATCH")
                {
                    context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                    using (StreamReader stream = new StreamReader(context.HttpContext.Request.Body))
                    {
                        body = stream.ReadToEnd();
                    }
                    Error += $"Body: {body}" + Environment.NewLine;
                }

                Error += Environment.NewLine;
                Error += context.Exception.Message + Environment.NewLine;
                Error += "************************************************************************";

                logErrorBusiness.Log(methodname, $"{Error} + , Uri:  {context.HttpContext.Request.GetDisplayUrl()}");
            }
        }
    }
}
