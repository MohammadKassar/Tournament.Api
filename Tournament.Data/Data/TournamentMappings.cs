using AutoMapper;
using Tournament.Core.Dto;
using Tournament.Core.Entities;

namespace Tournament.Data.Data
{
    public class TournamentMappings : Profile
    {
        public TournamentMappings()
        {
            CreateMap<TournamentEntity, TournamentDto>()
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.StartDate.AddMonths(3)));
            CreateMap<TournamentDto, TournamentEntity>();

            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
        }
    }
}
