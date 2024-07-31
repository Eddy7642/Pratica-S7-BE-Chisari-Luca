namespace Pizzeria.Models
{
    public class OrdineArticolo
    {
        public int OrdineId { get; set; }
        public Ordine Ordine { get; set; }

        public int ArticoloId { get; set; }
        public Articolo Articolo { get; set; }
    }
}
