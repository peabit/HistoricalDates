using HistoricalDates.Application.Dtos.Date;
using HistoricalDates.Application.Features;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("dates")]
public sealed class UpdateEndpoint : ControllerBase
{
    private readonly UpdateCommand _command;

    public UpdateEndpoint(UpdateCommand command)
        => _command = command ?? throw new ArgumentNullException(nameof(command));

    [HttpPut("{dateId}")]
    public async Task<IActionResult> Handle(Guid dateId, IDateDto dateDto)
    {
        await _command.Execute(dateId, dateDto);
        return Ok();
    }
}