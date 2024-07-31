using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaInForno.Data;
using PizzeriaInForno.Models;

namespace PizzeriaInForno.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class OrdiniController : Controller
    {
        private readonly PizzeriaContext _context;

        public OrdiniController(PizzeriaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ordini = await _context.Ordini.Include(o => o.DettagliOrdine).ThenInclude(d => d.Articolo).ToListAsync();
            return View(ordini);
        }

        public async Task<IActionResult> Evadi(int id)
        {
            var ordine = await _context.Ordini.FindAsync(id);
            if (ordine != null)
            {
                ordine.Evasa = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
