//NOTE This was generated from the JSON
namespace Ratings.API.Model.Analyst
{
    public class AnalystRatingApiResponse
    {
        public List<Value>? values { get; set; }
    }

    public class Value
    {
        public string? Isin { get; set; }
        public string? Rating { get; set; }
    }
}
