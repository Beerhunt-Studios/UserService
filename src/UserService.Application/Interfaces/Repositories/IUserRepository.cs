using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseChord.Application.Repositories;
using UserService.Domain.Models;

namespace UserService.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> FindByExternalIdentifier(string externalIdentifier);
}
