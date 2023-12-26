using Microsoft.EntityFrameworkCore;
using olap_api.Data;
using olap_api.DTO;
using olap_api.Models;

namespace olap_api.Repositories
{
    public class DataPointRepository : IDataPointRpository
    {
        private readonly ApiDbContext apiDbContext;

        public DataPointRepository(ApiDbContext context)
        {
            this.apiDbContext = context;
        }

        public async Task CreateDataPointAsync(DataPoint dataPoint)
        {
            await apiDbContext.DataPoints.AddAsync(dataPoint);
            await apiDbContext.SaveChangesAsync();
        }

        public async Task<UpdateDataPointDTO> UpdateDataPointAsync(
            DataPoint existingDataPoint,
            Country existingCountry,
            Indicator existingIndicator,
            UpdateDataPointDTO requestDataPoint)
        {

            existingDataPoint.Countries = existingCountry;
            existingDataPoint.Indicators = existingIndicator;
            existingDataPoint.Frequency = requestDataPoint.Frequency;
            existingDataPoint.Date = requestDataPoint.Date;
            existingDataPoint.Value = requestDataPoint.Value;

            UpdateDataPointDTO updatedDataPoint = new UpdateDataPointDTO(existingDataPoint.Id, existingCountry.Id,
                existingIndicator.Id, requestDataPoint.Frequency, requestDataPoint.Date, requestDataPoint.Value);

            await apiDbContext.SaveChangesAsync();
            return updatedDataPoint;
        }

        public async Task<object> GetDataPointsAsync()
        {

            var rawData = await apiDbContext.DataPoints
           .Include(dp => dp.Countries)
           .Include(dp => dp.Indicators)
           .ToListAsync();

            var cubeResult = rawData
                .GroupBy(dp => new { dp.Countries.Name, dp.Countries.Code, dp.Countries.Id })
                .SelectMany(countryGroup =>
                    countryGroup.GroupBy(dp => new { dp.Indicators.Name, dp.Indicators.Code, dp.Indicators.Id })
                        .SelectMany(indicatorGroup =>
                            indicatorGroup.GroupBy(dp => dp.Frequency)
                                .SelectMany(frequencyGroup =>
                                    frequencyGroup.GroupBy(dp => dp.Date.ToString("yyyy-MM-dd"))
                                        .Select(dateGroup =>
                                            new
                                            {
                                                Id = dateGroup.First().Id,
                                                CountryName = countryGroup.Key.Name,
                                                CountryCode = countryGroup.Key.Code,
                                                CountryId = countryGroup.Key.Id,
                                                IndicatorId = indicatorGroup.Key.Id,
                                                IndicatorName = indicatorGroup.Key.Name,
                                                IndicatorCode = indicatorGroup.Key.Code,
                                                Frequency = frequencyGroup.Key,
                                                Date = dateGroup.Key,
                                                Value = dateGroup.Sum(dp => dp.Value)
                                            }
                                        )
                                )
                        )
                ).ToArray();
            return cubeResult;
        }

        public async Task<DataPoint?> GetDataPointAsync(Guid id)
        {
            return await apiDbContext.DataPoints
                .Include(x => x.Countries)
                .Include(x => x.Indicators)
                .FirstOrDefaultAsync(dataPoint => dataPoint.Id == id);
        }

        public async Task DeleteDataPointAsync(DataPoint dataPoint)
        {
            apiDbContext.DataPoints.Remove(dataPoint);
            await apiDbContext.SaveChangesAsync();
        }
    }
}
