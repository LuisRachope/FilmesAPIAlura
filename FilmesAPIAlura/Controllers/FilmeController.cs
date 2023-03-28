using AutoMapper;
using FilmesAPIAlura.Data;
using FilmesAPIAlura.Data.Dtos;
using FilmesAPIAlura.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPIAlura.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarFilmePorId),
            new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> ListarFilmes([FromQuery] int skip = 0, int take = 50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ListarFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

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

        _context.Filmes.Remove(filme);
        _context.SaveChanges();
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

        _context.Filmes.Add(_filme);
        _context.SaveChanges();
        return _filme;
    }
}
