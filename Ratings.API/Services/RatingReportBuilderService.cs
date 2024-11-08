using Ratings.API.DataProviders;
using Ratings.API.Model;
using Ratings.API.Model.Analyst;
using Ratings.API.Model.Instrument;
using Ratings.API.Model.Moodys;

namespace Ratings.API.Services
{
    public class RatingReportBuilderService : IRatingReportBuilderService
    {
        private IDataProvider<InstrumentApiResponse> _instrumentDataProvider;
        private IDataProvider<AnalystRatingApiResponse> _analystRatingsDataProvider;
        private IDataProvider<MoodysRatingApiResponse> _moodysRatingsDataProvider;

        public RatingReportBuilderService(
            IDataProvider<InstrumentApiResponse> instrumentDataProvider,
            IDataProvider<AnalystRatingApiResponse> analystRatingsDataProvider,
            IDataProvider<MoodysRatingApiResponse> moodysRatingsDataProvider)
        {
            _instrumentDataProvider = instrumentDataProvider;
            _analystRatingsDataProvider = analystRatingsDataProvider;
            _moodysRatingsDataProvider = moodysRatingsDataProvider;
        }

        public async Task<IEnumerable<RatingsReportData>> GetData()
        {
            var instrumentsTask = _instrumentDataProvider.Get();
            var analystRatingsTask = _analystRatingsDataProvider.Get();
            var moddysRatingsTask = _moodysRatingsDataProvider.Get();

            await Task.WhenAll(instrumentsTask, analystRatingsTask, moddysRatingsTask);

            var analystRatingsByIsin = analystRatingsTask.Result.values.Where(v => v?.Isin is not null).ToDictionary(v => v.Isin!, v => v);
            var moodysRatingsByIsin = moddysRatingsTask.Result.values.Where(v => v?.Isin is not null).ToDictionary(v => v.Isin!, v => v);

            var instrumentData = instrumentsTask.Result.values;
            var ratingsReport = new List<RatingsReportData>(instrumentData.Count());

            foreach (var instrument in instrumentData.Where(i => i is not null))
            {
                ratingsReport.Add(CreateInstrumentRatingsReportRow(analystRatingsByIsin, moodysRatingsByIsin, instrument));
            }

            return ratingsReport;
        }

        private RatingsReportData CreateInstrumentRatingsReportRow(
            Dictionary<string, Model.Analyst.Value> analystRatingsByIsin,
            Dictionary<string, Model.Moodys.Value> moodysRatingsByIsin,
            Model.Instrument.Value instrument)
        {
            var analystRating = "Not available";
            var moodysRating = "Not available";
            if (instrument?.identifiers?.Isin is not null)
            {
                //Only try and get the ratings if we have an ISIN to key on

                if (analystRatingsByIsin.TryGetValue(instrument.identifiers.Isin, out var analystRatingVal) &&
                    analystRatingVal?.Rating is not null)
                {
                    analystRating = analystRatingVal.Rating;
                }

                if (moodysRatingsByIsin.TryGetValue(instrument.identifiers.Isin, out var moodysRatingVal) &&
                    moodysRatingVal?.Rating is not null)
                {
                    moodysRating = moodysRatingVal.Rating;
                }
            }

            return new RatingsReportData(
                Isin: instrument!.identifiers?.Isin,
                Sedol: instrument.identifiers?.Sedol,
                baseCcy: instrument.domCcy,
                InstrumentName: instrument.name,
                InstrumentType: instrument.instrumentDefinition?.instrumentType,
                AnalystRating: analystRating,
                MoodysRating: moodysRating);
        }
    }
}
