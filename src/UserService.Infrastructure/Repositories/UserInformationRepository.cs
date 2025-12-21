using System.Linq;
using System.Threading.Tasks;
using BaseChord.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ThreadSafe;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Repositories;

public class UserInformationRepository : GenericRepository<UserInformation>, IUserInformationRepository
{
    public UserInformationRepository(ThreadSafeDbContext dbContext) : base(dbContext)
    {
    }

    public Task<UserInformation?> FindByExternalId(string externalId)
    {
        return Entities.Where(x => x.User.ExternalIdentifier == externalId).SingleOrDefaultAsync();
    }
}
