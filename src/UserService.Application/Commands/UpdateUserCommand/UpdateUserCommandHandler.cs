using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BaseChord.Application.Database;
using BaseChord.Application.Exceptions;
using MediatR;
using UserService.Application.Interfaces.Repositories;
using UserService.Domain.Models;

namespace UserService.Application.Commands.UpdateUserCommand;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IUserInformationRepository _userInformationRepository;
    private readonly IDbTransactionFactory _dbTransactionFactory;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserInformationRepository userInformationRepository, IDbTransactionFactory dbTransactionFactory, IMapper mapper)
    {
        _userInformationRepository = userInformationRepository;
        _dbTransactionFactory = dbTransactionFactory;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userInfo = await _userInformationRepository.FindByExternalId(request.ExternalIdentifier);

        if (userInfo is null)
        {
            throw new NotFoundException(typeof(UserInformation), -1);
        }

        using IDbTransaction transaction = await _dbTransactionFactory.CreateTransaction();
        _mapper.Map(request, userInfo);
        await _userInformationRepository.UpdateAsync(userInfo);

        await transaction.CommitAsync(cancellationToken);

        return true;
    }
}
