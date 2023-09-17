using HistoricalDates.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalDates.WebAPI.Endpoints;

[ApiController]
[Route("dates")]
public sealed class DeleteEndpoint : ControllerBase
{
    private readonly DeleteCommand _command;

    public DeleteEndpoint(DeleteCommand command) 
        => _command = command ?? throw new ArgumentNullException(nameof(command));

    [HttpDelete("{dateId}")]
    public async Task<IActionResult> Handle(Guid dateId)
    {
        await _command.Execute(dateId);
        return Ok();
    }
}