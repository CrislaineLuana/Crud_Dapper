using Crud_Dapper.Models;
using Dapper;
using System.Data.SqlClient;

namespace Crud_Dapper.Service.LivroService
{
    public class LivroService : ILivrosInterface
    {

        private readonly IConfiguration _configuration;
        private readonly string getConnection;
        public LivroService(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");
        }



        public async Task<IEnumerable<Livros>> GetAllLivros()
        {

            using(var con = new SqlConnection(getConnection))
            {
                var sql = "select * from livros";
                return await con.QueryAsync<Livros>(sql);
            }

        }

        public async Task<Livros> GetLivrosById(int livroId)
        {
            using(var con = new SqlConnection(getConnection))
            {
                var sql = "select * from livros where id = @id";
                return await con.QueryFirstOrDefaultAsync<Livros>(sql, new { id = livroId});
            }


        }


        public async Task<IEnumerable<Livros>> CreateLivro(Livros livro)
        {
            using (var con = new SqlConnection(getConnection))
            {

                

                var sql = "insert into livros (titulo, autor) values (@titulo, @autor)";
                await con.ExecuteAsync(sql, livro);

                return await con.QueryAsync<Livros>("select * from livros");
            }
        }

        public async Task<IEnumerable<Livros>> UpdateLivro(Livros livro)
        {
            using (var con = new SqlConnection(getConnection))
            {

                var sql = "update livros set titulo = @titulo, autor = @autor where id = @id";
                await con.ExecuteAsync(sql, livro);

                return await con.QueryAsync<Livros>("select * from livros");
            }
        }

        public async Task<IEnumerable<Livros>> DeleteLivro(int livroId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "delete from livros where id = @id";
                await con.ExecuteAsync(sql, new {id = livroId});

                return await con.QueryAsync<Livros>("select * from livros");
            }
        }

    }
}
