using Microsoft.EntityFrameworkCore;
using olap_api.Data;
using olap_api.DTO;
using olap_api.Models;

namespace olap_api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApiDbContext apiDbContext;

        public CountryRepository(ApiDbContext context)
        {
            this.apiDbContext = context;
        }
        public async Task CreateCountryAsync(Country country)
        {
            await apiDbContext.Countries.AddAsync(country);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task<UpdateCountryDTO> UpdateCountryAsync(Country existingCountry, UpdateCountryDTO requestCountry)
        {
            existingCountry.Name = requestCountry.Name;
            existingCountry.Code = requestCountry.Code;
            UpdateCountryDTO updatedCountry = new UpdateCountryDTO(existingCountry.Id, requestCountry.Name, requestCountry.Code);
            await apiDbContext.SaveChangesAsync();
            return updatedCountry;
        }

        public async Task<Country?> GetCountryAsync(Guid id)
        {
            return await apiDbContext.Countries.FirstOrDefaultAsync(country => country.Id == id);
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await apiDbContext.Countries.ToListAsync();
        }

        public async Task DeleteCountryAsync(Country country)
        {
            apiDbContext.Countries.Remove(country);
            await apiDbContext.SaveChangesAsync();
        }
    }
}
