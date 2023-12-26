using olap_api.DTO;
using olap_api.Models;

namespace olap_api.Repositories
{
    public interface IIndicatorRepository
    {
        public Task CreateIndicatorAsync(Indicator indicator);
        public Task<Indicator?> GetIndicatorAsync(Guid id);
        public Task<IEnumerable<Indicator>> GetIndicatorsAsync();
        public Task DeleteIndicatorAsync(Indicator indicator);
        public Task<UpdateIndicatorDTO> UpdateIndicatorAsync(Indicator existingIndicator, UpdateIndicatorDTO requestIndicator);
    }
}
