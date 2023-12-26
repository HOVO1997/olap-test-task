using olap_api.DTO;
using olap_api.Models;

namespace olap_api.Repositories
{
    public interface IDataPointRpository
    {
        public Task CreateDataPointAsync(DataPoint dataPoint);
        public Task<DataPoint?> GetDataPointAsync(Guid id);
        public Task<object> GetDataPointsAsync();
        public Task DeleteDataPointAsync(DataPoint dataPoint);
        public Task<UpdateDataPointDTO> UpdateDataPointAsync(DataPoint existingDataPoint, Country existingCountry, Indicator existingIndicator, UpdateDataPointDTO requestDataPoint);
    }
}
