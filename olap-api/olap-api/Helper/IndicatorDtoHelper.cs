using olap_api.DTO;
using olap_api.Models;

namespace olap_api.Helper
{
    public static class IndicatorDtoHelper
    {
        public static IndicatorDTO AsDto(this Indicator indicator)
        {
            return new IndicatorDTO(indicator.Id, indicator.Name, indicator.Code);
        }
    }
}
