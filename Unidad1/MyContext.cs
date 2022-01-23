using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Configuration;
namespace Unidad1
{
    public class MyContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Posts> Posteos { get; set; }
        public DbSet<Comments> Comentarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-EA5G5R7I\SQLEXPRESS;Database=Unidad1;Trusted_Connection=True;");
        }        
    }
}
