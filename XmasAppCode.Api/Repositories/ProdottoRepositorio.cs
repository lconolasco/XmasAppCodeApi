using Microsoft.EntityFrameworkCore;
using XmasAppCode.Api.Context;
using XmasAppCode.Api.Entities;
using XmasAppCode.Api.Interfaces;

namespace XmasAppCode.Api.Repositories
{
    public class ProdottoRepositorio : IProdottoRepositorio
    {
        private readonly AppDbContext _context;

        public ProdottoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Prodotto> RicuperaProdottoPerBarcode(string barcode)
        {
            return await _context.Prodotti.FirstOrDefaultAsync(p => p.Barcode == barcode);
        }

        public async Task<IEnumerable<Prodotto>> RicuperaProdottoPerNome(string nome)
        {
            return await _context.Prodotti.ToListAsync();
        }
        public async Task<IEnumerable<Prodotto>> RicuperaTuttiProdotti()
        {
            return await _context.Prodotti.ToListAsync();
        } 
        public async Task<Prodotto> AggiungeProdotto(Prodotto prodotto)
        {            
            await _context.Prodotti.AddAsync(prodotto);
            await _context.SaveChangesAsync(); 

            return prodotto;
        }

        public async Task<Prodotto> AggiornaProdotto(Prodotto prodotto, string barcode)
        {
            Prodotto prodottoBarcode = await RicuperaProdottoPerBarcode(barcode);

            if(prodottoBarcode is null)
            {
                throw new Exception($"Il prodotto di barcode: {barcode} non è presente su questa banca dati");
            }

            prodottoBarcode.Nome = prodotto.Nome;
            prodottoBarcode.Descrizione = prodotto.Descrizione;
            prodottoBarcode.Prezzo = prodotto.Prezzo;
            prodottoBarcode.PesoLordo = prodotto.PesoLordo;
            prodottoBarcode.CategoriaId = prodotto.CategoriaId;

            _context.Prodotti.Update(prodottoBarcode);
           await _context.SaveChangesAsync();

            return prodottoBarcode;
        }

       /* public async Task<Prodotto> CancelaProdotto(string barcode)
        {
            Prodotto prodottoBarcode = await RicuperaProdottoPerBarcode(barcode);

            if (prodottoBarcode is null)
            {
                throw new Exception($"Il prodotto di barcode: {barcode} non è presente su questa banca dati");
            }
            
            _context.prodotti.Remove(prodottoBarcode);
            await _context.SaveChangesAsync();
            return prodottoBarcode;
        }*/

        public async Task<bool> CancelaProdotto(string barcode)
        {
            Prodotto prodottoBarcode = await RicuperaProdottoPerBarcode(barcode);

            if (prodottoBarcode is null)
            {
                throw new Exception($"Il prodotto di barcode: {barcode} non è presente su questa banca dati");
            }

            _context.Prodotti.Remove(prodottoBarcode);
            await _context.SaveChangesAsync();
            return true;
        }

        Task<Prodotto> IProdottoRepositorio.RicuperaProdottoPerNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
