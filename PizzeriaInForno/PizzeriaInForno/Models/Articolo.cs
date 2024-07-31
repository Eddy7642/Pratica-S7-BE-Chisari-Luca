namespace PizzeriaInForno.Models
{
    public class Articolo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public decimal Prezzo { get; set; }
        public int TempoConsegna { get; set; }
        public string Ingredienti { get; set; }
    }
}
