using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        [Key]

        public int Id { get; set; }
        [MaxLength(256)]
        public string Login { get; set; }
        [MaxLength(256)]
        public string Password { get; set; }
        public UserType Type { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(UserGroup))]
        public int? GroupId { get; set; }
        public UserGroup? UserGroup { get; set; }
    }

    public enum UserType
    {
        Admin = 0,
        Casual = 1,
    }
}
