using HistoricalDates.Application.Dtos.Date;
using HistoricalDates.Domain.HistoricalDate;

namespace HistoricalDates.Application.Features;

public sealed class AddCommand
{
    private readonly Mapper _mapper;
    private readonly IHistoricalDateRepository _repository;

    public AddCommand(Mapper mapper, IHistoricalDateRepository repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Execute(IDateDto dateDto)
    {
        var historicalDate = _mapper.MapHistoricalDate(dateDto);
        await _repository.AddAsync(historicalDate);
    }
}