using Microsoft.EntityFrameworkCore;
using XmasAppCode.Api.Context;
using XmasAppCode.Api.Entities;
using XmasAppCode.Api.Interfaces;

namespace XmasAppCode.Api.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly AppDbContext _context;
        public CategoriaRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Categoria> AggiornaCategoria(Categoria categoria, int id)
        {
            Categoria categoriaId = await RicuperaCategoriaPerId(id);
            if(categoriaId is null)
            {
                throw new Exception($"Categoria con ID: {id} no è presente nella banca dati Categoria.");
            }
            categoriaId.Nome = categoria.Nome;

            _context.Categorie.Update(categoriaId);
            await _context.SaveChangesAsync();
            
            return categoriaId;
        }

        public async Task<Categoria> AgiungeCategoria(Categoria categoria)
        {
            await _context.Categorie.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> CancelaCategoria(int id)
        {
            Categoria categoriaId = await RicuperaCategoriaPerId(id);
            _context.Categorie.Remove(categoriaId);
            _context.SaveChanges();
            return true;
        }

        public async Task<Categoria> RicuperaCategoriaPerId(int id)
        {
            return await _context.Categorie.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Categoria>?> RicuperaCategoriaPerNome(string nome)
        {
            return await _context.Categorie.FirstOrDefaultAsync(c => c.Nome.Contains(nome)) as IEnumerable<Categoria>;

        }

        public async Task<IEnumerable<Categoria>> RicuperaTutteCategorie()
        {
            return await _context.Categorie.ToListAsync();
        }
    }
}
