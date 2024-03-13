using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public IEnumerable<OrderPosition>? Positions { get; set; }
    }
}
