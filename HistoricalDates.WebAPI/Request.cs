using Microsoft.AspNetCore.Mvc;

namespace HistoricalDates.WebAPI
{
    //[BindProperties]
    public class Request
    {
        //public Request(string myProperty)
        //{
        //    MyProperty = myProperty;
        //}

        public Property MyProperty { get; init; }
    }

    public class Property
    {
        public string Data { get; set; }
    }
}
