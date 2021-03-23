using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OperationQuasarFireApp.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OperationQuasarFireApp.CustomExceptionsMiddleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// </summary>
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ErrorException ex)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.NotFound, ex.Message);
            }
            catch (MessageLengthNotValidException ex)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.NotFound, ex.Message);
            }
            catch (SatellitesIsNullException ex)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.NotFound, ex.Message);
            }
            catch (SatellitesUpdateDataException ex)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode errorType, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorType;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new {
                messageError = message
            }));
        }
    }
}
