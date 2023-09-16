using HistoricalDates.Domain.Seedwork;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalDates.WebAPI;

public static class ProblemDetailsExceptionHandler
{
    public static void UseProblemDetailsExceptionHandler(this WebApplication app)
        => app.UseExceptionHandler(exceptionHandlerApp => exceptionHandlerApp.Run(Handle));

    private static async Task Handle(HttpContext context)
    {
        var exceptionHandlerPathFeature =
            context.Features.Get<IExceptionHandlerPathFeature>()!;

        var problemDetailsFactory =
            context.RequestServices.GetService<ProblemDetailsFactory>()!;

        var problemDetails = 
            CreateProblemDetails(context, exceptionHandlerPathFeature.Error, problemDetailsFactory);

        context.Response.StatusCode = problemDetails.Status!.Value;
        await context.Response.WriteAsJsonAsync(problemDetails);
    }

    private static ProblemDetails CreateProblemDetails(HttpContext context, Exception exception, ProblemDetailsFactory problemDetailsFactory)
    {
        if (exception is DomainException domainException)
            return problemDetailsFactory.CreateProblemDetails(context, StatusCodes.Status400BadRequest, detail: domainException.Message);

        return problemDetailsFactory.CreateProblemDetails(context, StatusCodes.Status500InternalServerError, title: "Internal server error");
    }
}