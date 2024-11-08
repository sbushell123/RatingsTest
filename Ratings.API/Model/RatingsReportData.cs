namespace Ratings.API.Model
{
    public record RatingsReportData(
        string? Isin,
        string? Sedol,
        string? InstrumentName,
        string? InstrumentType,
        string? baseCcy,
        string? MoodysRating,
        string? AnalystRating);
}
