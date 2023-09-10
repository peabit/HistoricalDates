using HistoricalDates.Domain.DateModel;
using HistoricalDates.Domain.HistoricalDate;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;


//BsonSerializer.RegisterSerializer(new ObjectSerializer(type => true));
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

var client = new MongoClient();
var db = client.GetDatabase("dates");
var collection = db.GetCollection<HistoricalDate>("dates");

var dates = new List<HistoricalDate>()
{
    HistoricalDate.CreateByDate(new Day(5, 6, 50), "Описание даты", circa: true)
};

collection.InsertMany(dates);

var dateFromDb = collection.Find(new BsonDocument()).First();

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