/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ErrorHandlingMiddleware.cs                        //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Http;
using OffRoadPortal.Exceptions;

namespace OffRoadPortal.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch(FrobidException forbidException)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync(forbidException.Message);
        }
        catch(BadRequestException badRequestExeption)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(badRequestExeption.Message);
        }
        catch(NotFoundException notFoundException)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(notFoundException.Message);
        }
        catch(Exception e)
        {
            _logger.LogError(e, e.Message);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}