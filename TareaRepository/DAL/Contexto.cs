using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaRepository.Entidades;
namespace TareaRepository.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Empleado> Empleado { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
