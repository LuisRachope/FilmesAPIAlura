using FilmesAPIAlura.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPIAlura.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> ListarFilmes()
        {
            return filmes;
        }

        [HttpGet("{id}")]
        public Filme? ListarFilmePorId(int id)
        {
            return filmes.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("{id}")]
        public bool DeletarFilme(int id)
        {
            Filme? filme = ListarFilmePorId(id);

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
            Filme? _filme = ListarFilmePorId(id);

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
