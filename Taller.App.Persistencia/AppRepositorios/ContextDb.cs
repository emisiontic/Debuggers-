using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taller.App.Dominio;

namespace Taller.App.Persistencia
{
    public class ContextDb : DbContext
    {
        public DbSet<Mecanico> Mecanicos {get; set;}
        public DbSet<Dueno> Duenos {get; set;}
        public DbSet<Vehiculo> Vehiculos {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:mintic3-server.database.windows.net,1433;Initial Catalog=mintic3-database;Persist Security Info=False;User ID=TIC-ADMIN;Password=Grupo7*2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

    }


}