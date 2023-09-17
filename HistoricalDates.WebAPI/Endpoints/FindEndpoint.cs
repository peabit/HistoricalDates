using HistoricalDates.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalDates.WebAPI.Endpoints;

[ApiController]
[Route("dates")]
public sealed class FindEndpoint : ControllerBase
{
    private readonly FindQuery _query;

    public FindEndpoint(FindQuery query) 
        => _query = query ?? throw new ArgumentNullException(nameof(query));

    [HttpGet("{fromCentury}&{toCentury}")]
    public async Task<IActionResult> Handle(int fromCentury, int toCentury, [FromQuery]string[]? tags)
    {
        var dates = await _query.Execute(fromCentury, toCentury, tags);

        return dates.Any() ? Ok(dates) : NotFound();
    }
}