using Crud_Dapper.Models;

namespace Crud_Dapper.Service
{
    public interface ILivrosInterface
    {

        Task<IEnumerable<Livros>> GetAllLivros();
        Task<Livros> GetLivrosById(int livroId);
        Task<IEnumerable<Livros>> CreateLivro(Livros livro);
        Task<IEnumerable<Livros>> UpdateLivro(Livros livro);
        Task<IEnumerable<Livros>> DeleteLivro(int livroId);
    }
}
