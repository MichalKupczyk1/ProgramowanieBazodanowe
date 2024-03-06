using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserGroup
    {
        [Key]

        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public IEnumerable<User>? Users { get; set; }
    }
}
