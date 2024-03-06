using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Product
    {
        [Key]

        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [MaxLength(255)]
        public string Image { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(ProductGroup))]
        public int? GroupId { get; set; }
        public ProductGroup? Group { get; set; }
        public IEnumerable<BasketPosition>? BasketPositions { get; set; }
    }
}