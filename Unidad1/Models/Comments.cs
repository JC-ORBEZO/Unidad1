using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad1
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        public string Contenido { get; set; }
        public Usuario Usuario { get; set; }
    }
}
