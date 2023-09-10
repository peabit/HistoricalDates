using HistoricalDates.Domain.DateModel;
using HistoricalDates.Domain.HistoricalDate;
using HistoricalDates.Infrastructure;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;


//BsonSerializer.RegisterSerializer(new ObjectSerializer(type => true));
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

var client = new MongoClient();
var db = client.GetDatabase("dates");
var collection = db.GetCollection<HistoricalDate>("dates");

var repository = new MongoDbHistoricalDateRepository(collection);

//await repository.DeleteAsync(new Guid("8d804eef-2014-4e5e-866c-025f0e409430"));

;

//await repository.AddAsync(HistoricalDate.CreateByDate(new Day(1, 1, 2001), "Описание", tags: new string[] { "test" }));

var fd = await repository.FindAsync();

;

//var sortStrategy = Builders<HistoricalDate>
//    .Sort
//    .Ascending(d => d.Interval.BeginDayNumber)
//    .Descending(d => d.Interval.EndDayNumber);

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.Run();