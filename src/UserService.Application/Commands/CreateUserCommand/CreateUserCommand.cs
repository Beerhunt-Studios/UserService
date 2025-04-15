using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;
using UserService.Domain.Enum;

namespace UserService.Application.Commands.CreateUserCommand;

public record CreateUserCommand : IRequest<bool>
{
    [JsonIgnore]
    public string? ExternalIdentifier { get; set; }

    public string? FirstName { get; set; }

    public string? Lastname { get; set; }

    public string? ArtistName { get; set; }

    public Gender? Gender { get; set; }

    public DateOnly BirthDate { get; set; }

    public string? Ort { get; set; }
}
