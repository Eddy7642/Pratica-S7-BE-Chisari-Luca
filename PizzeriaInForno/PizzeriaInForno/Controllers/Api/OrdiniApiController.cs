using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaInForno.Data;

namespace PizzeriaInForno.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdiniApiController : ControllerBase
    {
        private readonly PizzeriaContext _context;

        public OrdiniApiController(PizzeriaContext context)
        {
            _context = context;
        }

        [HttpGet("evasi")]
        public async Task<IActionResult> GetOrdiniEvasi()
        {
            var ordiniEvasi = await _context.Ordini.Where(o => o.Evasa).ToListAsync();
            return Ok(ordiniEvasi);
        }

        [HttpGet("totaleincasso/{data}")]
        public async Task<IActionResult> GetTotaleIncasso(DateTime data)
        {
            var totale = await _context.Ordini
                .Where(o => o.Evasa && o.DataOrdine.Date == data.Date)
                .SumAsync(o => o.DettagliOrdine.Sum(d => d.Articolo.Prezzo * d.Quantita));
            return Ok(totale);
        }
    }
}
