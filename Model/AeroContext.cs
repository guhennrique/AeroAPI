using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroAPI.Model
{
    public class AeroContext : DbContext
    {
        public DbSet<Local> Locais { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Voo> Voos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=aero_db;Username=postgres;Password=postgres");
    }
}
