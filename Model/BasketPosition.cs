using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BasketPosition
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
    }
}
