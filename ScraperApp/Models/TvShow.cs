using AutoMapper;
using ScraperApp.Dtos;

namespace ScraperApp.Models;

public record TvShow
{
    public int ApiId { get; set; }
    public required string Name {get; set; }
};

public class TvShowMappingProfile : Profile
{
    public TvShowMappingProfile()
    {
        CreateMap<TvShowDto, TvShow>()
            .ForMember(m => m.ApiId, opt => opt.MapFrom(src => src.Id));


    }
}