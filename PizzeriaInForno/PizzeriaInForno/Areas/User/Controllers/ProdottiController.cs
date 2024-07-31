using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaInForno.Data;
using PizzeriaInForno.Models;

namespace PizzeriaInForno.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "user")]
    public class ProdottiController : Controller
    {
        private readonly PizzeriaContext _context;

        public ProdottiController(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Articoli.ToListAsync());
        }

        [HttpPost]
        public IActionResult AggiungiAlCarrello(int id, int quantita)
        {
            var carrello = HttpContext.Session.GetObjectFromJson<List<DettaglioOrdine>>("Carrello") ?? new List<DettaglioOrdine>();
            var articolo = _context.Articoli.Find(id);
            if (articolo != null)
            {
                carrello.Add(new DettaglioOrdine { Articolo = articolo, Quantita = quantita });
                HttpContext.Session.SetObjectAsJson("Carrello", carrello);
            }
            return RedirectToAction("Index");
        }
    }
}
