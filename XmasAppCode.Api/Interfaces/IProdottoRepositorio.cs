using XmasAppCode.Api.Entities;

namespace XmasAppCode.Api.Interfaces
{
    public interface IProdottoRepositorio
    {
        Task<IEnumerable<Prodotto>> RicuperaTuttiProdotti();
        Task<Prodotto> RicuperaProdottoPerBarcode(string barcode);
        Task<Prodotto> RicuperaProdottoPerNome(string nome);
        Task<Prodotto> AggiungeProdotto(Prodotto prodotto);
        Task<Prodotto> AggiornaProdotto(Prodotto prodotto, string barcode);
        //Task<Prodotto> CancelaProdotto(string barcode);
        Task<bool> CancelaProdotto(string barcode);
    }
}
