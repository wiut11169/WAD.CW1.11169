using AutoMapper;
using WAD.CW1._11169.DAL.Dtos;
using WAD.CW1._11169.DAL.Models;

namespace WAD.CW1._11169.DAL.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
        }
    }
}
