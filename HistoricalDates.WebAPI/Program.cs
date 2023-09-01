using MongoDB.Driver;
using MongoDB.Bson;
using HistoricalDates.Domain.Model;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

// Categories, Aristotle - Middle, 4 BC
// Apology, Plato - The first half, 4 BC

// Meditations, Marcus Aurelius - The second half, 2 AD

// Candide - 1759
// Critique of Pure Reason - 1781

// Human, All Too Human - 1878
// Eugene Onegin - 1833

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

var client = new MongoClient();
var db = client.GetDatabase("dates");
var dates = db.GetCollection<Date>("dates");
//var dates = db.GetCollection<CenturyPart>("dates").FindSync(new BsonDocument { { "_t", "CenturyPart" } }).ToList();

var guid = new Guid("39610029771ea74c9e0e4a0fc74b176c");

//var q = dates.Find(new BsonDocument { { "_id", "47731ae8-639f-476a-8786-7d4c8d4cb57a" } }).ToList();

await InitDb(dates);

;

static async Task InitDb(IMongoCollection<Date> dates)
{
    var cp1 = new CenturyPart()
    {
        Century = 4,
        Part = CenturyPart.CenturyPartValue.TheMiddle,
        Era = Era.BC,
        Description = "Categories - Aristotle",
        Tags = new[] { "Philosophy", "Ancient philosophy" }
    };

    var cp2 = new CenturyPart()
    {
        Century = 4,
        Part = CenturyPart.CenturyPartValue.TheFirstHalf,
        Era = Era.BC,
        Description = "Apology - Plato",
        Tags = new[] { "Philosophy", "Ancient philosophy" }
    };

    var cp3 = new CenturyPart()
    {
        Century = 2,
        Part = CenturyPart.CenturyPartValue.TheLastHalf,
        Era = Era.BC,
        Description = "Meditations, Marcus Aurelius",
        Tags = new[] { "Philosophy", "Ancient philosophy", "" }
    };

    var y1 = new YearOnly()
    {
        Year = 1759,
        Description = "Candide - Voltaire",
        Tags = new[] { "Philosophy", "Age of Enlightenment" }
    };

    var y2 = new YearOnly()
    {
        Year = 1781,
        Description = "Critique of Pure Reason - Immanuel Kant",
        Tags = new[] { "Philosophy", "Age of Enlightenment" }
    };

    var y3 = new YearOnly()
    {
        Year = 1878,
        Description = "Human, All Too Human - Friedrich Nietzsche",
        Tags = new[] { "Philosophy", "Lebensphilosophie", "Continental philosophy" }
    };

    var y4 = new YearOnly()
    {
        Year = 1833,

        Description = "Eugene Onegin - Alexander Pushkin",
        Tags = new[] { "Literature", "Russian literature" }
    };

    await dates.InsertManyAsync(new Date[]
    {
        y1,
        y2,
        y3,
        y4,
        cp1,
        cp2,
        cp3,
    });
}

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.Run();