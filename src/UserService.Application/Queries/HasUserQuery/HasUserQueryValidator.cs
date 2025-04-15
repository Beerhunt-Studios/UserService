using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace UserService.Application.Queries.HasUserQuery;

public class HasUserQueryValidator : AbstractValidator<HasUserQuery>
{
    public HasUserQueryValidator()
    {
        RuleFor(x => x.ExternalIdentifier).NotNull().NotEmpty();
    }
}
