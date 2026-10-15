using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Application.Common;
using FluentValidation;

namespace Products.Api.Middleware
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context, Exception exception, CancellationToken ct)
        {
            ProblemDetails problem;

            switch (exception)
            {
                case ValidationException ex:
                    problem = new ValidationProblemDetails(
                        ex.Errors.GroupBy(e => e.PropertyName)
                                 .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray()))
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = "Validation failed"
                    };
                    break;

                case NotFoundException ex:
                    problem = new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Not found",
                        Detail = ex.Message
                    };
                    break;

                default:
                    logger.LogError(exception, "Unhandled exception");
                    problem = new ProblemDetails
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Title = "Server error"
                    };
                    break;
            }

            context.Response.StatusCode = problem.Status!.Value;
            await context.Response.WriteAsJsonAsync(problem, ct);
            return true;
        }
    }
}
