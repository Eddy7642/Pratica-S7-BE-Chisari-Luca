using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;


public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PizzeriaContext(
            serviceProvider.GetRequiredService<DbContextOptions<PizzeriaContext>>()))
        {
            // Controlla se ci sono già articoli nel database
            if (context.Articoli.Any())
            {
                return;   // Il database è stato già popolato
            }

            context.Articoli.AddRange(
                new Articolo
                {
                    Nome = "Margherita",
                    FotoUrl = "url/margherita.jpg",
                    Prezzo = 5.00m,
                    TempoConsegna = 30,
                    Ingredienti = "Pomodoro, Mozzarella"
                },
                new Articolo
                {
                    Nome = "Diavola",
                    FotoUrl = "url/diavola.jpg",
                    Prezzo = 6.50m,
                    TempoConsegna = 35,
                    Ingredienti = "Pomodoro, Mozzarella, Salame Piccante"
                },
                new Articolo
                {
                    Nome = "Quattro Stagioni",
                    FotoUrl = "url/quattrostagioni.jpg",
                    Prezzo = 7.00m,
                    TempoConsegna = 40,
                    Ingredienti = "Pomodoro, Mozzarella, Prosciutto, Funghi, Carciofi, Olive"
                }
            );

            context.Utenti.AddRange(
                new Utente
                {
                    Nome = "Admin",
                    Email = "admin@pizzeria.com",
                    Password = "admin"
                },
                new Utente
                {
                    Nome = "User1",
                    Email = "user1@pizzeria.com",
                    Password = "password1"
                }
            );

            context.SaveChanges();
        }
    }
}
