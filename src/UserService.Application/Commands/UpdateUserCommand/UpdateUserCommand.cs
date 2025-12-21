using System;
using BaseChord.Application.Models;
using MediatR;
using UserService.Domain.Enum;

namespace UserService.Application.Commands.UpdateUserCommand;

public class UpdateUserCommand : IRequest<bool>
{
    public string? ExternalIdentifier { get; set; } = null!;

    public Optional<string> ArtistName { get; set; }

    public Optional<Gender> Gender { get; set; }

    public Optional<string> Ort { get; set; }

    public Optional<int[]> Genre { get; set; }
}
