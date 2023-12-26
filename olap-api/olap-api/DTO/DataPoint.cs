using olap_api.Models;

namespace olap_api.DTO
{
    public record DataPointDTO(Guid Id, Country Countries, Indicator Indicators, string Frequency, DateTime Date, decimal Value);
    public record CreateDataPointDTO(Guid Id, Guid CountryId, Guid IndicatorId, string Frequency, DateTime Date, decimal Value);
    public record UpdateDataPointDTO(Guid Id, Guid CountryId, Guid IndicatorId, string Frequency, DateTime Date, decimal Value);
}
