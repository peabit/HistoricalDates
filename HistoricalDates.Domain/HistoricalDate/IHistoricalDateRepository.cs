using HistoricalDates.Domain.DateModel;
using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.HistoricalDate;

public interface IHistoricalDateRepository
{
    Task AddAsync(HistoricalDate historicalDate);

    Task<IEnumerable<HistoricalDate>> FindAsync(Interval interval, string[]? tags = default!);

    Task UpdateAsync(Guid id, HistoricalDate newHistoricalDate);
    
    Task DeleteAsync(Guid id);
}