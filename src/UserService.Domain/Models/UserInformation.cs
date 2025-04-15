using System;
using System.Collections.Generic;
using System.Text;
using BaseChord.Domain;
using UserService.Domain.Enum;

namespace UserService.Domain.Models;

public class UserInformation : IEntity
{
    public int Id { get; private set; }

    public int UserId { get; private set; }

    public User User { get; private set; } = null!;

    public string FirstName { get; private set; } = null!;

    public string Lastname { get; private set; } = null!;

    public string ArtistName { get; private set; } = null!;

    public Gender Gender { get; private set; }

    public DateOnly BirthDate { get; private set; }

    public string Ort { get; private set; } = null!;

    public UserInformation(int userId)
    {
        UserId = userId;
    }
}
