using Microsoft.AspNetCore.Mvc;
using XmasAppCode.Api.Entities;
using XmasAppCode.Api.Interfaces;
using XmasAppCode.Api.Repositories;

namespace XmasAppCode.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> RicuperaTutteCategorie()
        {
            IEnumerable<Categoria> categorie = await _categoriaRepositorio.RicuperaTutteCategorie();
            return Ok(categorie);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> RicuperaCategoriePerId(int id)
        {
            Categoria categoria = await _categoriaRepositorio.RicuperaCategoriaPerId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> AggiuingeCategoria([FromBody] Categoria categoria)
        {
            Categoria nuovaCategoria = await _categoriaRepositorio.AgiungeCategoria(categoria);
            return Ok(nuovaCategoria);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Categoria>> AggiornaCategoria(Categoria categoria, int id)
        {
            categoria.Id = id;
            Categoria categoriaAggiornata = await _categoriaRepositorio.AggiornaCategoria(categoria, id);
            return Ok(categoriaAggiornata);
        }

        [HttpDelete("{id}")]
        public  async Task<ActionResult<Categoria>> CancelaCategoria(int id)
        {
            bool cancelato = await _categoriaRepositorio.CancelaCategoria(id);
            return Ok(cancelato);
        }
    }

}