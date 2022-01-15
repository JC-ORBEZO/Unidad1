using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad1
{
    public class Comments
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Contenido { get; set; }
        public Usuario Usuario { get; set; }
    }
}
