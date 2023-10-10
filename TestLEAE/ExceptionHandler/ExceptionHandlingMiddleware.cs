using FluentValidation;
using System.Net;

namespace TestLEAE;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next, 
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var code = GetResponse(ex);
            _logger.LogError(ex, "error during executing {Context}", context.Request.Path.Value);
            context.Response.Redirect($"Error?code={(int)code}");
        }
    }
    public HttpStatusCode GetResponse(Exception exception)
    {
        HttpStatusCode code;
        switch (exception)
        {
            case KeyNotFoundException:
                code = HttpStatusCode.NotFound;
                break;
            case ArgumentException
                or InvalidOperationException
                or ValidationException:
                code = HttpStatusCode.BadRequest;
                break;
            default:
                code = HttpStatusCode.InternalServerError;
                break;
        }
        return code;
    }
}