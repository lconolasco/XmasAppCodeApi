namespace XmasAppCode.Api.Entities
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string? Barcode { get; set; }
        public string? Nome { get; set; }
        public  string? ImageUrl { get; set; }
        public string? Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public decimal PesoLordo { get; set; }

        //Questa proprietà sarà creata nel DB come una chiave straniera
        public int? CategoriaId { get; set; }
    }
}
