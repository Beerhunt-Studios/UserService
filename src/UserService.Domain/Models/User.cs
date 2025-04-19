using System;
using System.Collections.Generic;
using System.Text;
using BaseChord.Domain;

namespace UserService.Domain.Models;

public class User : IPersistentEntity
{
    public int Id { get; set; }

    public bool IsDeleted { get; private set; }

    public string ExternalIdentifier { get; private set; } = null!;

    public void SetAsDeleted() => IsDeleted = true;

    private User()
    {

    }

    public User(string externalIdentifier)
    {
        ExternalIdentifier = externalIdentifier;
    }
}
