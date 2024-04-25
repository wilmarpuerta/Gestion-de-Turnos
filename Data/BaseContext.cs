using Gestion_de_Turnos.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Turnos.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<Turno> Turnos { get; set;}
    }
}