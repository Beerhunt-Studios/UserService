using System.Threading.Tasks;
using BaseChord.Application.Repositories;
using UserService.Domain.Models;

namespace UserService.Application.Interfaces.Repositories;

public interface IUserInformationRepository : IGenericRepository<UserInformation>
{
    Task<UserInformation?> FindByExternalId(string externalId);
}
