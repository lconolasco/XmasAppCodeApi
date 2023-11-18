using XmasAppCode.Api.Entities;

namespace XmasAppCode.Api.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<IEnumerable<Categoria>> RicuperaTutteCategorie();
        Task<Categoria> RicuperaCategoriaPerId(int id);
        Task<IEnumerable<Categoria>> RicuperaCategoriaPerNome(string nome);
        Task<Categoria> AgiungeCategoria(Categoria categoria);
        Task<Categoria> AggiornaCategoria(Categoria categoria, int Id);
        Task<bool> CancelaCategoria(int id);
    }
}
