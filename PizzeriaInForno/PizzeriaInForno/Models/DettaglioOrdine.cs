namespace PizzeriaInForno.Models
{
    public class DettaglioOrdine
    {
        public int Id { get; set; }
        public int OrdineId { get; set; }
        public Ordine Ordine { get; set; }
        public int ArticoloId { get; set; }
        public Articolo Articolo { get; set; }
        public int Quantita { get; set; }
    }
}
