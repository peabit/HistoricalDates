//using HistoricalDates.Domain.DateModel.Base;
//using HistoricalDates.Domain.DateModel;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using MongoDB.Bson.Serialization;

//namespace HistoricalDates.Application.DateSearchService;

//public sealed class DateSearchService
//{
//    private readonly IMongoDatabase _db;
//    private readonly FilterDefinitionBuilder<BsonDocument> _filterBuilder = Builders<BsonDocument>.Filter;

//    public DateSearchService(IMongoDatabase db)
//    {

//        _db = db;
//    }

//    public void Find(FindDatesQuery query)
//    {
//        var yearFilter = BuildYearFilter(
//            fromYear: new Year(query.FromCentury.Begin.Year, query.FromCentury.Era),
//            toYear: new Year(query.ToCentury.End.Year, query.ToCentury.Era)
//        );

//        var dates = _db.GetCollection<BsonDocument>("dates");

//        var result = dates.Find(yearFilter).ToList();

//        ;
//    }

//    private FilterDefinition<BsonDocument> BuildYearFilter(Year fromYear, Year toYear)
//    {
//        var filter = _filterBuilder.Eq("Era", fromYear.Era);

//        if (fromYear.Era is Era.AD)
//        {
//            return filter &
//                 _filterBuilder.Gte("Year", fromYear.Value) &
//                 _filterBuilder.Lte("Year", toYear.Value);
//        }

//        filter &= _filterBuilder.Lte("Year", fromYear.Value);

//        if (toYear.Era is Era.BC)
//        {
//            return filter & _filterBuilder.Gte("Year", toYear.Value);
//        }

//        return filter | _filterBuilder.Lte("Year", toYear.Value) & _filterBuilder.Eq("Era", Era.AD);
//    }
//}