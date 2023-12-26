namespace olap_api.DTO
{
    public record IndicatorDTO(Guid Id, string Name, string Code);
    public record CreateIndicatorDTO(Guid Id, string Name, string Code);
    public record UpdateIndicatorDTO(Guid Id, string Name, string Code);
}
