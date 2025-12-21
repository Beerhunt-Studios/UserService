using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseChord.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ThreadSafe;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Hilfstexte;

namespace UserService.Infrastructure.Repositories;

public class MusicGenreRepository : GenericRepository<MusicGenre>, IMusicGenreRepository
{
    public MusicGenreRepository(ThreadSafeDbContext dbContext) : base(dbContext)
    {
    }

    public Task<List<MusicGenre>> ListByIds(params int[] ids)
    {
        return Entities.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
