using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BaseChord.Application.Validation;

namespace UserService.Application.Commands.CreateUserCommand;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private static DateOnly MinDate => DateOnly.FromDateTime(DateTime.Now).AddYears(-18);
    private static DateOnly MaxDate => DateOnly.FromDateTime(DateTime.Now).AddYears(-100);

    public CreateUserCommandValidator()
    {
        RuleFor(x => x.ExternalIdentifier)
            .NotEmpty();

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotServer()
            .MaximumLength(254);

        RuleFor(x => x.Lastname)
            .NotEmpty()
            .NotServer()
            .MaximumLength(254);

        RuleFor(x => x.ArtistName)
            .NotEmpty()
            .NotServer()
            .MaximumLength(254);

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .InclusiveBetween(MaxDate, MinDate);

        RuleFor(x => x.Gender)
            .NotEmpty();

        RuleFor(x => x.Ort)
            .NotEmpty()
            .NotServer()
            .MaximumLength(254);
    }
}
