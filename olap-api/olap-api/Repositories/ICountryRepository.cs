using olap_api.DTO;
using olap_api.Models;

namespace olap_api.Repositories
{
    public interface ICountryRepository
    {
        public Task CreateCountryAsync(Country country);
        public Task<Country?> GetCountryAsync(Guid id);
        public Task<IEnumerable<Country>> GetCountriesAsync();
        public Task DeleteCountryAsync(Country country);
        public Task<UpdateCountryDTO> UpdateCountryAsync(Country existingCountry, UpdateCountryDTO requestCountry);
    }
}
