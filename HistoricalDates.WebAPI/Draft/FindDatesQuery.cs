namespace HistoricalDates.WebAPI.Draft;

public sealed record FindDatesQuery(
    int CenturyFrom, 
    int CenturyTo, 
    IEnumerable<string> Tags
);