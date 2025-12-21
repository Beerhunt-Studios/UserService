using System.Collections.Generic;
using AutoMapper;
using BaseChord.Application.Models;
using UserService.Application.Commands.UpdateUserCommand;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Hilfstexte;
using UserService.Domain.Models;

namespace UserService.Application.Mappings;

public class MusicGenreResolver : IValueResolver<UpdateUserCommand, UserInformation, ICollection<MusicGenre>>
{
    private readonly IMusicGenreRepository _musicGenreRepository;

    public MusicGenreResolver(IMusicGenreRepository musicGenreRepository)
    {
        _musicGenreRepository = musicGenreRepository;
    }

    public ICollection<MusicGenre> Resolve(UpdateUserCommand source, UserInformation destination, ICollection<MusicGenre> destMember, ResolutionContext context)
    {
        if (!source.Genre.HasValue)
        {
            return destMember;
        }

        if (source.Genre.Value == null)
        {
            return [];
        }

        var musicGenres = _musicGenreRepository.ListByIds(source.Genre.Value).ConfigureAwait(false).GetAwaiter().GetResult();

        return musicGenres.ToArray();
    }
}
