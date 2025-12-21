using FluentValidation;

namespace UserService.Application.Commands.UpdateUserCommand;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.ExternalIdentifier)
            .NotEmpty();
    }
}
