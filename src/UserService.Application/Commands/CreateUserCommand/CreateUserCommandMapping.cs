using AutoMapper;
using BaseChord.Application.Mapping;
using UserService.Domain.Models;

namespace UserService.Application.Commands.CreateUserCommand;

public class CreateUserCommandMapping : IMap<CreateUserCommand, UserInformation>
{
    public void Mapping(IMappingExpression<CreateUserCommand, UserInformation> mapping)
    {
        mapping
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Lastname))
            .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.ArtistName))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.Ort, opt => opt.MapFrom(src => src.Ort))
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
