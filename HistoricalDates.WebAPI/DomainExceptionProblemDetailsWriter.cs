using HistoricalDates.Domain.Seedwork;
using Microsoft.AspNetCore.Diagnostics;

namespace HistoricalDates.WebAPI;

public class DomainExceptionProblemDetailsWriter : IProblemDetailsWriter
{
    public bool CanWrite(ProblemDetailsContext context)
    {
        var exceptionHandlerPathFeature = 
            context.HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        return exceptionHandlerPathFeature?.Error is DomainException;
    }

    public ValueTask WriteAsync(ProblemDetailsContext context)
    {
        throw new NotImplementedException();
    }
}
