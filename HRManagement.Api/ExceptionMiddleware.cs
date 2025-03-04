using HRManagement.Api.Models;
using HRManagement.Application.Exceptions;
using System.Net;
using System.Runtime.InteropServices;

namespace HRManagement.Api
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext,ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomProblemDetails problem = new();

            switch (ex)
            {
                case NotFoundException notFoundException:
                    {
                        statusCode = HttpStatusCode.BadRequest;
                        problem = new CustomProblemDetails
                        {
                            Title = notFoundException.Message,
                            Status = (int)statusCode,
                            Detail = notFoundException.InnerException?.Message,
                            Type = nameof(NotFoundException),
                            Errors = notFoundException.ValidationErrors

                        };
                    }

                    break;
                case BadRequestException badRequestException:
                    {
                        statusCode = HttpStatusCode.BadRequest;
                        problem = new CustomProblemDetails
                        {
                            Title = badRequestException.Message,
                            Status = (int)statusCode,
                            Detail = badRequestException.InnerException?.Message,
                            Type = nameof(BadRequestException),
                            Errors = badRequestException.ValidationErrors

                        };
                    }

                    break;
                default:
                    {
                        problem = new CustomProblemDetails
                        {
                            Title = ex.Message,
                            Status = (int)statusCode,
                            Detail = ex.StackTrace,
                            Type = nameof(HttpStatusCode.InternalServerError),

                        };
                    }
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
