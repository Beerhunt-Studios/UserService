using AutoMapper;
using BaseChord.Application.Mapping;
using UserService.Application.Mappings;
using UserService.Domain.Models;

namespace UserService.Application.Commands.UpdateUserCommand;

public class UpdateUserCommandMapping : IMap<UpdateUserCommand, UserInformation>
{
    public void Mapping(IMappingExpression<UpdateUserCommand, UserInformation> mapping)
    {
        mapping
            .ForMember(dest => dest.Ort, opt => opt.MapFromOptional(src => src.Ort))
            .ForMember(dest => dest.ArtistName, opt => opt.MapFromOptional(src => src.ArtistName))
            .ForMember(dest => dest.Gender, opt => opt.MapFromOptional(src => src.Gender))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom<MusicGenreResolver>())
            .ForMember(dest => dest.FirstName, opt => opt.Ignore())
            .ForMember(dest => dest.LastName, opt => opt.Ignore())
            .ForMember(dest => dest.BirthDate, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
