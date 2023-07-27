using Crud_Dapper.Models;
using Crud_Dapper.Service;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Crud_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {


        private readonly ILivrosInterface _livrosInterface;
        public LivrosController(ILivrosInterface livrosInterface)
        {
            _livrosInterface = livrosInterface;
        }


        [HttpGet]
        public async Task<ActionResult<List<Livros>>> GetAllLivros()
        {
            
            var livros = await _livrosInterface.GetAllLivros();

            if (!livros.Any())
            {
                return NotFound("Nenhum registro localizado!");
            }

            return Ok(livros);
        }


        [HttpGet("{livroId}")]
        public async Task<ActionResult<Livros>> GetLivrosById(int livroId)
        {
            Livros livro = await _livrosInterface.GetLivrosById(livroId);

            if (livro == null)
            {
                return NotFound("Registro não localizado!");
            }


            return Ok(livro);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<Livros>>> CreateLivro(Livros livro)
        {
            IEnumerable<Livros> livros = await _livrosInterface.CreateLivro(livro);

            return Ok(livros);
        }


        [HttpPut]
        public async Task<ActionResult<IEnumerable<Livros>>> UpdateLivro(Livros livro)
        {
            Livros registro = await _livrosInterface.GetLivrosById(livro.Id);

            if (registro == null)
            {
                return NotFound("Registro não localizado!");
            }

            IEnumerable<Livros> livros = await _livrosInterface.UpdateLivro(livro);
          

            return Ok(livros);
        }


        [HttpDelete("{livroId}")]
        public async Task<ActionResult<IEnumerable<Livros>>> DeleteLivro(int livroId)
        {
            Livros registro = await _livrosInterface.GetLivrosById(livroId);

            if (registro == null)
            {
                return NotFound("Registro não localizado!");
            }

            IEnumerable<Livros> livros = await _livrosInterface.DeleteLivro(livroId);

            return Ok(livros);
        }

    }
}
