using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application.DTO;
using users_app.DataAccess;

namespace users_app.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator(UserContext con)
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(30)
                .WithMessage("Username must be at least 4 and no more than 30 characters!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Password can not be less than 8 characters!");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30)
                .WithMessage("First name must be at least 3 and no more than 30 characters!");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30)
                .WithMessage("Last name must be at least 3 and no more than 30 characters!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Please enter a valid email!")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Email).Must((user, email) =>
                    {
                        return !con.Users.Any(u => u.Email == email);
                    })
                    .WithMessage("This email is already taken by another user!");
                });
        }
    }
}
