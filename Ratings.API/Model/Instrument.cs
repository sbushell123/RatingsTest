//NOTE This was generated from the JSON - would use official version from vendor if available

namespace Ratings.API.Model.Instrument
{
    public class InstrumentApiResponse
    {
        public List<Value> values { get; set; }
    }

    public class FlowConventions
    {
        public string currency { get; set; }
        public string paymentFrequency { get; set; }
        public string dayCountConvention { get; set; }
        public string rollConvention { get; set; }
        public List<string> paymentCalendars { get; set; }
        public List<string> resetCalendars { get; set; }
        public int settleDays { get; set; }
        public int resetDays { get; set; }
        public bool leapDaysIncluded { get; set; }
        public string accrualDateAdjustment { get; set; }
        public string businessDayConvention { get; set; }
        public string accrualDayCountConvention { get; set; }
    }

    public class Identifiers
    {
        public string Isin { get; set; }
        public string ClientInternal { get; set; }
        public string LusidInstrumentId { get; set; }
        public string Sedol { get; set; }
    }

    public class InstrumentDefinition
    {
        public Identifiers identifiers { get; set; }
        public string domCcy { get; set; }
        public int lotSize { get; set; }
        public string instrumentType { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? maturityDate { get; set; }
        public FlowConventions flowConventions { get; set; }
        public double? principal { get; set; }
        public double? couponRate { get; set; }
        public string calculationType { get; set; }
        public List<object> roundingConventions { get; set; }
        public string code { get; set; }
        public int? contractSize { get; set; }
        public string payCcy { get; set; }
        public int? referenceRate { get; set; }
        public string type { get; set; }
        public string underlyingCcy { get; set; }
        public string underlyingIdentifier { get; set; }
    }

     public class StagedModifications
    {
        public int countPending { get; set; }
        public string hrefPending { get; set; }
        public List<object> idsPreviewed { get; set; }
    }

    public class Value
    {
        public string href { get; set; }
        public string scope { get; set; }
        public string lusidInstrumentId { get; set; }
        public Version version { get; set; }
        public StagedModifications stagedModifications { get; set; }
        public string name { get; set; }
        public Identifiers identifiers { get; set; }
        public List<object> properties { get; set; }
        public InstrumentDefinition instrumentDefinition { get; set; }
        public string state { get; set; }
        public string assetClass { get; set; }
        public string domCcy { get; set; }
        public List<object> relationships { get; set; }
    }

    public class Version
    {
        public DateTime effectiveFrom { get; set; }
        public DateTime asAtDate { get; set; }
        public DateTime asAtCreated { get; set; }
        public string userIdCreated { get; set; }
        public string requestIdCreated { get; set; }
        public DateTime asAtModified { get; set; }
        public string userIdModified { get; set; }
        public string requestIdModified { get; set; }
        public int asAtVersionNumber { get; set; }
        public string entityUniqueId { get; set; }
    }


}
