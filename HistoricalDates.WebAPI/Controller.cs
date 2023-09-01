using Microsoft.AspNetCore.Mvc;

namespace HistoricalDates.WebAPI;

//[ApiController]
[Route("/")]
public class Controller : ControllerBase
{
    [HttpGet]
    public string Get(Request request)
    {
        return "Hello";
    }
}
