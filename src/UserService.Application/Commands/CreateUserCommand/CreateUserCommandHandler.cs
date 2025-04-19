using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseChord.Application.Database;
using BaseChord.Application.Exceptions;
using MediatR;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Models;

namespace UserService.Application.Commands.CreateUserCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IUserInformationRepository _userInformationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDbTransactionFactory _dbTransactionFactory;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserInformationRepository userInformationRepository, IDbTransactionFactory dbTransactionFactory, IUserRepository userRepository, IMapper mapper)
    {
        _userInformationRepository = userInformationRepository;
        _dbTransactionFactory = dbTransactionFactory;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.FindByExternalIdentifier(request.ExternalIdentifier!);
        if (user is not null)
        {
            throw new ApplicationException("User already exists");
        }

        user = new User(request.ExternalIdentifier!);
        UserInformation userInformation = new UserInformation(user);

        _mapper.Map(request, userInformation);

        var transaction = _dbTransactionFactory.CreateTransaction();
        await _userRepository.AddAsync(user);
        await _userInformationRepository.AddAsync(userInformation);
        await transaction.CommitAsync(cancellationToken);

        return true;
    }
}
