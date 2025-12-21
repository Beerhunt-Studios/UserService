using System.Collections.Generic;
using System.Threading.Tasks;
using BaseChord.Application.Repositories;
using UserService.Domain.Hilfstexte;

namespace UserService.Application.Interfaces.Repositories;

public interface IMusicGenreRepository : IGenericRepository<MusicGenre>
{
    Task<List<MusicGenre>> ListByIds(params int[] ids);
}
