using Microsoft.AspNetCore.Http;
using NLog;
using System;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.API.Middlewares
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                this.LogException(context, ex);
                throw;
            }
        }

        private void LogException(HttpContext context, Exception exception)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Error(exception, "Ein unerwarter Fehler ist aufgetreten in {request-method} {request-path}.", context.Request.Method, context.Request.Path);
        }
    }
}