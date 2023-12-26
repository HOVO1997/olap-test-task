using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace olap_api.Models
{
    public class DataPoint
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public Country Countries { get; set; }

        public Indicator Indicators { get; set; }

        public string Frequency { get; set; } = String.Empty;

        public DateTime Date { get; set; }

        public decimal Value { get; set; }
    }
}
