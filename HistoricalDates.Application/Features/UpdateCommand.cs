using HistoricalDates.Application.Dtos.Date;
using HistoricalDates.Domain.HistoricalDate;

namespace HistoricalDates.Application.Features;

public sealed class UpdateCommand
{
    private readonly Mapper _mapper;
    private readonly IHistoricalDateRepository _repository;

    public UpdateCommand(IHistoricalDateRepository repository, Mapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Execute(Guid id, IDateDto dateDto)
    {
        var date = _mapper.MapHistoricalDate(dateDto);
        await _repository.UpdateAsync(id, date);
    }
}