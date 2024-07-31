using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzeriaInForno.Data;
using PizzeriaInForno.Extensions; 
using PizzeriaInForno.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PizzeriaInForno.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "user")]
    public class CarrelloController : Controller
    {
        private readonly PizzeriaContext _context;

        public CarrelloController(PizzeriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var carrello = HttpContext.Session.GetObjectFromJson<List<DettaglioOrdine>>("Carrello") ?? new List<DettaglioOrdine>();
            return View(carrello);
        }

        [HttpPost]
        public async Task<IActionResult> ConcludiOrdine(string indirizzo, string note)
        {
            var carrello = HttpContext.Session.GetObjectFromJson<List<DettaglioOrdine>>("Carrello") ?? new List<DettaglioOrdine>();
            if (carrello.Count == 0) return RedirectToAction("Index");

            var ordine = new Ordine
            {
                UtenteId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                DettagliOrdine = carrello,
                IndirizzoSpedizione = indirizzo,
                Note = note,
                DataOrdine = DateTime.Now,
                Evasa = false
            };

            _context.Ordini.Add(ordine);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("Carrello");

            return RedirectToAction("Confermato");
        }

        public IActionResult Confermato()
        {
            return View();
        }
    }
}
