using System;
using System.Net;
using System.Threading.Tasks;
using HealthSanctuary.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace HealthSanctuary.Web.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ApplicationException ex)
            {
                HandleApplicationException(httpContext, ex);
            }
        }

        private void HandleApplicationException(HttpContext httpContext, ApplicationException exception)
        {
            if (exception is WorkoutOwnerException)
            {                
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (exception is MealUsedException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
