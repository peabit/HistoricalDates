using HistoricalDates.Domain.DateModel;
using HistoricalDates.Domain.DateModel.Base;

var dates = new List<Date>()
{
    new Year(501),
    new Year(506),
    new Day(6, 5, 503),
    new Year(201),
    new Year(202),
    new Year(400),
    new Day(1, 1, 201),
    new Day(2, 1, 201),
    new Month(7, 503),
    new Day(5, 5, 201),
    new Day(10, 10, 203),
    new Month(1, 201),
    new Month(6, 201),
    new Century(3),
    new Century(5),
};

dates.Sort();

;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.Run();