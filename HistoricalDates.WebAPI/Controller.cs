using HistoricalDates.Application;
using HistoricalDates.Application.Dtos.Date;
using Microsoft.AspNetCore.Mvc;

namespace HistoricalDates.WebAPI;

[ApiController]
[Route("dates")]
public class Controller : ControllerBase
{
    private readonly DatesService _datesService;

    public Controller(DatesService datesService) 
        => _datesService = datesService ?? throw new ArgumentNullException(nameof(datesService));

    [HttpPost]
    public async Task<IActionResult> Create(IDateDto date)
    {
        await _datesService.Add(date);
        return Ok();
    }
}