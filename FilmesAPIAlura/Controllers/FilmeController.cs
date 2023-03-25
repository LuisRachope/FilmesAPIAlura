using FilmesAPIAlura.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPIAlura.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(ListarFilmePorId), 
                new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> ListarFilmes([FromQuery] int skip = 0, int take = 50)
        {
            return filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult ListarFilmePorId(int id)
        {
            var filme = filmes.FirstOrDefault(x => x.Id == id);

            if (filme is null)
            {
                return NotFound();
            }

            return Ok(filme);
        }

        [HttpPost("{id}")]
        public bool DeletarFilme(int id)
        {
            var filme = (Filme?)ListarFilmePorId(id);

            if (filme is null)
            {
                return false;
            }

            filmes.Remove(filme);
            return true;
        }

        [HttpPut("{id}")]
        public Filme? EditarFilme([FromBody] Filme filme, int id)
        {
            var _filme = (Filme?)ListarFilmePorId(id);

            if (_filme is null)
            {
                return null;
            }

            _filme.Titulo = filme.Titulo;
            _filme.Genero = filme.Genero;
            _filme.Duracao = filme.Duracao;

            bool delete = DeletarFilme(id);

            filmes.Add(_filme);

            return _filme;
        }
    }
}
