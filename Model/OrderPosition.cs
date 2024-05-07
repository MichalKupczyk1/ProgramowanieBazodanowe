using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderPosition
    {
        [Key]

        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Order))]
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
