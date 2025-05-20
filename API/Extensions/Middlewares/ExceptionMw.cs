using Application.Dtos;
using Application.Dtos.Errors;
using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Security.Authentication;

namespace API.Extensions.Middlewares
{
    public static class ExceptionMw
    {
        public static void UseCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {

                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            AuthenticationException => StatusCodes.Status401Unauthorized,
                            _ => StatusCodes.Status500InternalServerError
                        };


                        await context.Response.WriteAsync(
                            new Result(
                                false,
                                new (context.Response.StatusCode.ToString(), contextFeature.Error.Message)
                            ).ToString()
                        );
                    }
                });
            });
        }
    }
}
