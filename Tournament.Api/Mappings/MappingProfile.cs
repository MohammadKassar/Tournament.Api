using AutoMapper;
using Tournament.Core.Dto;
using Tournament.Core.Entities;

namespace Tournament.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TournamentEntity, TournamentDto>().ReverseMap();
            CreateMap<Game, GameDto>().ReverseMap();
        }
    }
}
