using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChildrenParentProductGroup
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ProductGroup))]
        public int? ParentId { get; set; }

        public ProductGroup? Parent { get; set; }
        public IEnumerable<ProductGroup>? Children { get; set; }
    }
}
