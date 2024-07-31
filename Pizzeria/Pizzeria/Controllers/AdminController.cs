using Microsoft.AspNetCore.Mvc;
using Pizzeria.Data;
using System.Linq;

namespace Pizzeria.Controllers
{
    public class AdminController : Controller
    {
        private readonly PizzeriaContext _context;

        public AdminController(PizzeriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articoli = _context.Articolo.ToList();
            return View(articoli);
        }
    }
}
