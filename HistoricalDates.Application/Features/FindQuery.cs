using HistoricalDates.Domain.DateModel;
using HistoricalDates.Domain.HistoricalDate;

namespace HistoricalDates.Application.Features;

public sealed class FindQuery
{
    private readonly Mapper _mapper;
    private readonly IHistoricalDateRepository _repository;

    public FindQuery(Mapper mapper, IHistoricalDateRepository repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IEnumerable<HistoricalDate>> Execute(int fromCentury, int toCentury, string[]? tags)
    {
        var fromCenturyModel = _mapper.MapCentury(fromCentury);

        var toCenturyModel = _mapper.MapCentury(toCentury);

        var period = new Period<Century, Century>(fromCenturyModel, toCenturyModel);

        var interval = period.ToInterval();

        var dates = await _repository.FindAsync(interval, tags);

        return dates;
    }
}