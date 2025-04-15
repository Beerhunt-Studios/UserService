using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Application.Interfaces.Repositories;

namespace UserService.Application.Queries.HasUserQuery;

public class HasUserQueryHandler : IRequestHandler<HasUserQuery, bool>
{
    private readonly IUserRepository _userRepository;

    public HasUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(HasUserQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.ExternalIdentifier))
        {
            throw new InvalidOperationException("External identifier is required");
        }

        return await _userRepository.FindByExternalIdentifier(request.ExternalIdentifier) is not null;
    }
}
