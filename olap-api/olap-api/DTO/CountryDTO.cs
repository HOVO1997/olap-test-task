namespace olap_api.DTO
{
    public record CountryDTO(Guid Id, string Name, string Code);
    public record CreateCountryDTO(Guid Id, string Name, string Code);
    public record UpdateCountryDTO(Guid Id, string Name, string Code);
}
