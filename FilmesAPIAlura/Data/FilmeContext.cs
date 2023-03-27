using FilmesAPIAlura.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPIAlura.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options)
        : base(options)
    {
    }

    public DbSet<Filme> Filmes { get; set; }
}
