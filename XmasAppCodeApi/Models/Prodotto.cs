namespace XmasAppCodeApi.Models
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string? Barcode { get; set; }
        public string? Nome { get; set; }
        public string? Descrizione { get; set; }
        public decimal Peso { get; set; }
        public decimal Prezzo { get; set;}
    }
}
