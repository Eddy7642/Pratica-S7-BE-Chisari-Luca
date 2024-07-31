using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria.Data
{
    public class PizzeriaContext : IdentityDbContext<ApplicationUser>
    {
        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
            : base(options)
        {
        }

        public DbSet<OrdineArticolo> OrdineArticolo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrdineArticolo>()
                .HasKey(oa => new { oa.OrdineId, oa.ArticoloId });

            modelBuilder.Entity<OrdineArticolo>()
                .HasOne(oa => oa.Ordine)
                .WithMany(o => o.Articoli)
                .HasForeignKey(oa => oa.OrdineId);

            modelBuilder.Entity<OrdineArticolo>()
                .HasOne(oa => oa.Articolo)
                .WithMany(a => a.Ordini)
                .HasForeignKey(oa => oa.ArticoloId);
        }
    }
}
