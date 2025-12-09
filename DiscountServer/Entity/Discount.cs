using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountServer.Entity
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Column(TypeName ="decimal(8,2)")]
        public double Price { get; set; }
    }
}
