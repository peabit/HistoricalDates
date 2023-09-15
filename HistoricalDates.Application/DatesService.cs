using HistoricalDates.Application.Dtos.Date;
using HistoricalDates.Domain.HistoricalDate;

namespace HistoricalDates.Application;

public class DatesService
{
    private readonly Mapper _mapper;
    private readonly IHistoricalDateRepository _repository;

    public DatesService(IHistoricalDateRepository repository, Mapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Add(IDateDto dateDto)
    {
        var historicalDate = _mapper.Map(dateDto);
        await _repository.AddAsync(historicalDate);
    }
}