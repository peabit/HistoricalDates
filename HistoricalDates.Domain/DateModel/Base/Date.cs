namespace HistoricalDates.Domain.DateModel.Base;

public abstract record Date
{
    public Date(Era era) => Era = era;

    public Era Era { get; }
    
    public sealed override string ToString()
    {
        var date = DateToString();
        return Era is Era.BC ? $"{date} {Era}" : date;
    }

    public abstract Interval ToInterval();

    protected abstract string DateToString();
}