using AutoMapper;
using BaseChord.Application.Mapping;
using BaseChord.Contracts.Stammdaten.MusicGenre;
using UserService.Domain.Hilfstexte;

namespace UserService.Application.Eventbus.MusicGenreAddedEvent;

public class MusicGenreAddedMap : IMap<MusicGenreAdded, MusicGenre>
{
    public void Mapping(IMappingExpression<MusicGenreAdded, MusicGenre> mapping)
    {
        mapping
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.ParentId));
    }
}
