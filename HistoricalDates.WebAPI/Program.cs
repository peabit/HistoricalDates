using HistoricalDates.Application.Dtos.Date;
using HistoricalDates.Application.Dtos.DateValue;
using HistoricalDates.WebAPI;
using JsonSubTypes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddMongoDb();

builder.Services.AddMapper();

builder.Services.AddRepository();
    
builder.Services.AddFeatures();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(
        JsonSubtypesConverterBuilder
            .Of(typeof(IDateDto), "Type")
            .RegisterSubtype(typeof(SingleDateDto), DateType.Single)
            .RegisterSubtype(typeof(PeriodDateDto), DateType.Period)
            .SerializeDiscriminatorProperty()
            .Build()
    );

     options.SerializerSettings.Converters.Add(
         JsonSubtypesConverterBuilder
             .Of(typeof(IDateValueDto), "DateValueType")
             .RegisterSubtype(typeof(DayDto), DateValueType.Day)
             .RegisterSubtype(typeof(MonthDto), DateValueType.Month)
             .RegisterSubtype(typeof(YearDto), DateValueType.Year)
             .RegisterSubtype(typeof(CenturyDto), DateValueType.Century)
             .SerializeDiscriminatorProperty()
             .Build()
     );
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseProblemDetailsExceptionHandler();

app.Run();