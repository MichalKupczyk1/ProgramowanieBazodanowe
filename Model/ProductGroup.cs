using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductGroup
    {
        [Key]

        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }

        [ForeignKey(nameof(Parent))]
        public int? ParentId { get; set; }
        public ProductGroup? Parent { get; set; }
    }
}
