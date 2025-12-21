using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseChord.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ThreadSafe;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Repositories;

internal class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ThreadSafeDbContext dbContext) : base(dbContext)
    {
    }

    public Task<User?> FindByExternalIdentifier(string externalIdentifier)
    {
        return Entities.Where(x => x.ExternalIdentifier.Equals(externalIdentifier)).SingleOrDefaultAsync();
    }
}
