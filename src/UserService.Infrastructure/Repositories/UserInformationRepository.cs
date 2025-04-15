using System.Linq;
using System.Threading.Tasks;
using BaseChord.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Repositories;

public class UserInformationRepository : GenericRepository<UserInformation>, IUserInformationRepository
{
    public UserInformationRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public Task<UserInformation?> FindByExternalId(string externalId)
    {
        return Entities.Where(x => x.User.ExternalIdentifier == externalId).SingleOrDefaultAsync();
    }
}
