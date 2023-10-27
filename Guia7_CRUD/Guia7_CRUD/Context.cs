using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia7_CRUD
{
    public class Context : DbContext
    {

        public DbSet<EstudianteUNAB> Estudiante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-E6P6QHE\\SQLEXPRESS;Database=Program2;Trusted_Connection=True;");
            }
        }
    }
}
