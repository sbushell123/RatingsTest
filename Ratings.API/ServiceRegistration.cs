using Ratings.API.DataProviders;
using Ratings.API.Model;
using Ratings.API.Model.Analyst;
using Ratings.API.Model.Instrument;
using Ratings.API.Model.Moodys;
using Ratings.API.Services;

namespace Ratings.API
{
    public static class ServiceRegistration
    {
        public static void AddCustomServices(IServiceCollection services, ConfigurationManager config)
        {
            //NOTE This is for the IHttpClientFactory
            //Would add some retry policy to this using Polly in a real system
            services.AddHttpClient();


            services.AddScoped<IRatingReportBuilderService, RatingReportBuilderService>();
#pragma warning disable CS8604 // Possible null reference argument.
// NOTE Could have another layer to check the config and output a meaningful error if any is missing
            services.AddScoped<IDataProvider<InstrumentApiResponse>, DataProvider<InstrumentApiResponse>>(sp => new DataProvider<InstrumentApiResponse>(
                httpClient: sp.GetRequiredService<IHttpClientFactory>(),
                url: config.GetValue<string>("ApiAddress:InstrumentsUrl")));
            services.AddScoped<IDataProvider<MoodysRatingApiResponse>, DataProvider<MoodysRatingApiResponse>>(sp => new DataProvider<MoodysRatingApiResponse>(
                httpClient: sp.GetRequiredService<IHttpClientFactory>(),
                url: config.GetValue<string>("ApiAddress:MoodysRatingsUrl")));
            services.AddScoped<IDataProvider<AnalystRatingApiResponse>, DataProvider<AnalystRatingApiResponse>>(sp => new DataProvider<AnalystRatingApiResponse>(
                httpClient: sp.GetRequiredService<IHttpClientFactory>(),
                url: config.GetValue<string>("ApiAddress:AnalystRatingsUrl")));
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
