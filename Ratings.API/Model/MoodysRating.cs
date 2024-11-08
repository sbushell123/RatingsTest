//NOTE This was generated from the JSON - would use official version from vendor if available

namespace Ratings.API.Model.Moodys
{

    public class MoodysRatingApiResponse
    {
        public List<Value>? values { get; set; }
    }

    public class Value
    {
        public string? Isin { get; set; }
        public string? Rating { get; set; }
    }
}
