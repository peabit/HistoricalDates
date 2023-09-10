using HistoricalDates.Domain.DateModel;
using HistoricalDates.Domain.DateModel.Base;

namespace HistoricalDates.Domain.HistoricalDate;

public interface IHistoricalDateRepository
{
    Task AddAsync(HistoricalDate historicalDate);

    Task<IEnumerable<HistoricalDate>> FindAsync(Interval interval, string[] tags = default!);

    Task UpdateAsync(HistoricalDate historicalDate);
    
    Task DeleteAsync(Guid id);
}