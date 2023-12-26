using olap_api.DTO;
using olap_api.Models;

namespace olap_api.Helper
{
    public static class CountryDtoHelper
    {
        public static CountryDTO AsDto(this Country country)
        {
            return new CountryDTO(country.Id, country.Name, country.Code);
        }
    }
}
