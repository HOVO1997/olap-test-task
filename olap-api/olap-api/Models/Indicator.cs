using System.ComponentModel.DataAnnotations;

namespace olap_api.Models
{
    public class Indicator
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Code { get; set; } = String.Empty;
    }
}
