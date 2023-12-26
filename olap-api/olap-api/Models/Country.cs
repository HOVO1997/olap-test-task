using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace olap_api.Models
{
    public class Country
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Code { get; set; } = String.Empty;
    }
}
