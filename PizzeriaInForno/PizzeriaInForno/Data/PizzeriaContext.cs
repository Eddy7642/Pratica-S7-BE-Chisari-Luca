using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzeriaInForno.Models;

namespace PizzeriaInForno.Data
{
    public class PizzeriaContext : IdentityDbContext<IdentityUser>
    {
        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
            : base(options)
        {
        }

        public DbSet<Articolo> Articoli { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<DettaglioOrdine> DettagliOrdine { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DettaglioOrdine>()
                .HasOne(d => d.Ordine)
                .WithMany(o => o.DettagliOrdine)
                .HasForeignKey(d => d.OrdineId);

            builder.Entity<DettaglioOrdine>()
                .HasOne(d => d.Articolo)
                .WithMany()
                .HasForeignKey(d => d.ArticoloId);
        }
    }
}
