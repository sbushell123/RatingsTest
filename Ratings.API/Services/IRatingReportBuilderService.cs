using Ratings.API.Model;

namespace Ratings.API.Services
{
    public interface IRatingReportBuilderService
    {
        Task<IEnumerable<RatingsReportData>> GetData();
    }
}