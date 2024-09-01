
using System.ComponentModel.DataAnnotations;

namespace PerformanceTipsAssignment.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ManufacturingDate { get; set; }
    }

}
