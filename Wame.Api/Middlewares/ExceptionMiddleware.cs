using System.Text.Json;
using Wame.Application.Exceptions;

namespace Wame.Api.Middlewares;

public class ExceptionMiddleware
{
    private class ErrorDetails
    {
        public ErrorDetails(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (HttpException exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        if (exception is HttpException httpException)
        {
            context.Response.StatusCode = httpException.StatusCode;
        }

        await context.Response.WriteAsync(new ErrorDetails(exception.Message).ToString());
    }
}