using HistoricalDates.Domain.HistoricalDate;

namespace HistoricalDates.Application.Features;

public sealed class DeleteCommand
{
    private readonly IHistoricalDateRepository _repository;

    public DeleteCommand(IHistoricalDateRepository repository)
        => _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task Execute(Guid id)
        => await _repository.DeleteAsync(id);
}