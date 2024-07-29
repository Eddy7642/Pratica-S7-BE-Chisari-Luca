using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria.Data

{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Articolo> Articoli { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }
}
    
