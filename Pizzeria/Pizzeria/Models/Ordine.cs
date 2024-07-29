namespace Pizzeria.Models
{
    public class Ordine
    {
        public int Id { get; set; }
        public int UtenteId { get; set; }
        public List<OrdineArticolo> Articoli { get; set; }
        public string IndirizzoSpedizione { get; set; }
        public string Note { get; set; }
        public bool Evaso { get; set; }
        public DateTime DataOrdine { get; set; }
    }
}
