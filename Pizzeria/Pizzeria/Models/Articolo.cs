using System.Collections.Generic;

namespace Pizzeria.Models
{
    public class Articolo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }

        public ICollection<OrdineArticolo> Ordini { get; set; }
    }
}
