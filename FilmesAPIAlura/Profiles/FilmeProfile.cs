using AutoMapper;
using FilmesAPIAlura.Data.Dtos;
using FilmesAPIAlura.Models;

namespace FilmesAPIAlura.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
    }
}
