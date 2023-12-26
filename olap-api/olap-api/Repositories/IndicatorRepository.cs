using Microsoft.EntityFrameworkCore;
using olap_api.Data;
using olap_api.DTO;
using olap_api.Models;

namespace olap_api.Repositories
{
    public class IndicatorRepository : IIndicatorRepository
    {
        private readonly ApiDbContext apiDbContext;

        public IndicatorRepository(ApiDbContext context)
        {
            this.apiDbContext = context;
        }

        public async Task CreateIndicatorAsync(Indicator indicator)
        {
            await apiDbContext.Indicators.AddAsync(indicator);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task<UpdateIndicatorDTO> UpdateIndicatorAsync(Indicator existingIndicator, UpdateIndicatorDTO requestIndicator)
        {
            existingIndicator.Name = requestIndicator.Name;
            existingIndicator.Code = requestIndicator.Code;
            UpdateIndicatorDTO updatedRequestIndicator = new UpdateIndicatorDTO(existingIndicator.Id, requestIndicator.Name, requestIndicator.Code);
            await apiDbContext.SaveChangesAsync();
            return updatedRequestIndicator;
        }

        public async Task<Indicator?> GetIndicatorAsync(Guid id)
        {
            return await apiDbContext.Indicators.FirstOrDefaultAsync(indicator => indicator.Id == id);
        }

        public async Task<IEnumerable<Indicator>> GetIndicatorsAsync()
        {
            return await apiDbContext.Indicators.ToListAsync();

        }
        public async Task DeleteIndicatorAsync(Indicator indicator)
        {
            apiDbContext.Indicators.Remove(indicator);
            await apiDbContext.SaveChangesAsync();
        }
    }
}
