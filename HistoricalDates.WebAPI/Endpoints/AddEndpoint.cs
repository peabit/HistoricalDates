using HistoricalDates.Application.Dtos.Date;
using HistoricalDates.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalDates.WebAPI.Endpoints;

[ApiController]
[Route("dates")]
public sealed class AddEndpoint : ControllerBase
{
    private readonly AddCommand _handler;

    public AddEndpoint(AddCommand handler)
        => _handler = handler ?? throw new ArgumentNullException(nameof(handler));

    [HttpPost]
    public async Task<IActionResult> Handle(IDateDto date)
    {
        await _handler.Execute(date);
        return Ok();
    }
}