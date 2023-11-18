using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmasAppCode.Api.Entities;
using XmasAppCode.Api.Interfaces;
using XmasAppCode.Api.Repositories;

namespace XmasAppCode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottoController : ControllerBase
    {
        private readonly IProdottoRepositorio _prodottoRepositorio;
        public ProdottoController(IProdottoRepositorio prodottoRepositorio)
        {
            _prodottoRepositorio = prodottoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prodotto>>> RicuperaTuttiProdotti()
        {
            IEnumerable<Prodotto> prodotti = await _prodottoRepositorio.RicuperaTuttiProdotti();
            return Ok(prodotti);
        }

        [HttpGet("{barcode}")]
        public async Task<ActionResult<Prodotto>> RicuperaProdottoPerBarcode(string barcode)
        {
            Prodotto prodotto = await _prodottoRepositorio.RicuperaProdottoPerBarcode(barcode);
            return Ok(prodotto);
        }

        [HttpPost]
        public  async Task<ActionResult<Prodotto>> AggiungeProdotto([FromBody] Prodotto prodotto)
        {
            Prodotto nuovoProdotto = await _prodottoRepositorio.AggiungeProdotto(prodotto);
            return Ok(nuovoProdotto);
        }

        [HttpPatch("{barcode}")]
        public  async Task<ActionResult<Prodotto>> AggiornaProdotto([FromBody]Prodotto prodotto, string barcode)
        {
            prodotto.Barcode = barcode;
            Prodotto prodottoAggiornato = await _prodottoRepositorio.AggiornaProdotto(prodotto, barcode);
            prodottoAggiornato.Nome = prodotto.Nome;
            prodottoAggiornato.Descrizione = prodotto.Descrizione;
            prodottoAggiornato.ImageUrl = prodotto.ImageUrl;
            prodottoAggiornato.Prezzo = prodotto.Prezzo;
            prodottoAggiornato.PesoLordo = prodotto.PesoLordo;
            prodottoAggiornato.CategoriaId = prodotto.CategoriaId;

            return Ok(prodottoAggiornato); 
        }

        [HttpDelete("{barcode}")]
        public async Task<ActionResult<Prodotto>> CancelaProdotto(string barcode)
        {
            bool cancelato = await _prodottoRepositorio.CancelaProdotto(barcode);
            return Ok(cancelato);
        }
    }
}
