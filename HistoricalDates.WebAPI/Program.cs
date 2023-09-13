using HistoricalDates.WebAPI;
using JsonSubTypes;
using Newtonsoft;

//BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    //Register the subtypes of the Device (Phone and Laptop)
    //and define the device Discriminator
    options.SerializerSettings.Converters.Add(
        JsonSubtypesConverterBuilder
            .Of(typeof(IDateValue), "DateValueType")
            .RegisterSubtype(typeof(DayDto), DateValueType.DayDto)
            .RegisterSubtype(typeof(MonthDto), DateValueType.MonthDto)
            .SerializeDiscriminatorProperty()
            .Build()
    );

    options.SerializerSettings.Converters.Add(
        JsonSubtypesConverterBuilder
            .Of(typeof(IDate), "DateType")
            .RegisterSubtype(typeof(SingleDate), DateType.SingleDate)
            .RegisterSubtype(typeof(Period), DateType.Period)
            .SerializeDiscriminatorProperty()
            .Build()
    );
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();