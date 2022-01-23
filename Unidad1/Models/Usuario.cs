using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad1
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
