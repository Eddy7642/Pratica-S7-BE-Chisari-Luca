namespace PizzeriaInForno.Models
{
    public class Ordine
    {
        public int Id { get; set; }
        public string UtenteId { get; set; }
        public List<DettaglioOrdine> DettagliOrdine { get; set; }
        public string IndirizzoSpedizione { get; set; }
        public string Note { get; set; }
        public bool Evasa { get; set; }
        public DateTime DataOrdine { get; set; }
    }
}
