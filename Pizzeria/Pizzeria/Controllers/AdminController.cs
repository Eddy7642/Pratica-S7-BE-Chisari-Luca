using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Data;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly PizzeriaContext _context;

        public AdminController(PizzeriaContext context)
        {
            _context = context;
        }

        public IActionResult Articoli()
        {
            var articoli = _context.Articoli.ToList();
            return View(articoli);
        }

        [HttpPost]
        public IActionResult AggiungiArticolo(Articolo articolo)
        {
            _context.Articoli.Add(articolo);
            _context.SaveChanges();
            return RedirectToAction("Articoli");
        }

        public IActionResult Ordini()
        {
            var ordini = _context.Ordini.Include(o => o.Articoli).ToList();
            return View(ordini);
        }

        [HttpPost]
        public IActionResult SegnaComeEvaso(int id)
        {
            var ordine = _context.Ordini.Find(id);
            if (ordine != null)
            {
                ordine.Evaso = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Ordini");
        }

        public IActionResult ReportGiornaliero(DateTime data)
        {
            var ordiniEvaso = _context.Ordini.Where(o => o.DataOrdine.Date == data.Date && o.Evaso).ToList();
            var totaleIncassato = ordiniEvaso.Sum(o => o.Articoli.Sum(a => a.Articolo.Prezzo * a.Quantita));
            var numeroOrdiniEvasi = ordiniEvaso.Count;

            return Json(new { numeroOrdiniEvasi, totaleIncassato });
        }
    }

}
