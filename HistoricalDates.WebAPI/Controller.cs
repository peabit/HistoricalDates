
using Microsoft.AspNetCore.Mvc;

namespace HistoricalDates.WebAPI;

[ApiController]
[Route("dates")]
public class Controller : ControllerBase
{
    [HttpPost]
    public IActionResult Create(IDate date)
    {
        //var v = new DateDtoValidator();
        //var result = v.Validate(date);

        return Ok();
    }
}