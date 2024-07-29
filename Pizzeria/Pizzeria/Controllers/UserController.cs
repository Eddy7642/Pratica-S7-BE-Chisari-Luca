using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Data;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly PizzeriaContext _context;

        public UserController(PizzeriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articoli = _context.Articoli.ToList();
            return View(articoli);
        }

        [HttpPost]
        public IActionResult EffettuaOrdine(List<OrdineArticolo> articoli, string indirizzoSpedizione, string note)
        {
            var ordine = new Ordine
            {
                UtenteId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Articoli = articoli,
                IndirizzoSpedizione = indirizzoSpedizione,
                Note = note,
                DataOrdine = DateTime.Now
            };

            _context.Ordini.Add(ordine);
            _context.SaveChanges();

            return RedirectToAction("RiepilogoOrdine", new { id = ordine.Id });
        }

        public IActionResult RiepilogoOrdine(int id)
        {
            var ordine = _context.Ordini.Include(o => o.Articoli).ThenInclude(a => a.Articolo).FirstOrDefault(o => o.Id == id);
            return View(ordine);
        }
    }
}
