using BaseChord.Domain;

namespace UserService.Domain.Hilfstexte;

public class MusicGenre : IEntity
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public int? ParentId { get; private set; }
}
