using Microsoft.AspNetCore.Http;
using ProCodeIT.Template.BLL.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProCodeIT.Template.API.Infra.Exceptions
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null)
            {
                return;
            }

            HttpStatusCode code = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case BusinessException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case ArgumentException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case InvalidOperationException:
                    code = HttpStatusCode.Unauthorized;
                    break;
            }

            await WriteExceptionAsync(context, exception, code).ConfigureAwait(false);
        }

        private async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)code;

            await response.WriteAsJsonAsync(new { message = exception.Message }).ConfigureAwait(false);
        }
    }
}
