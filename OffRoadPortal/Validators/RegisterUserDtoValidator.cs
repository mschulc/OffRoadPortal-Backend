/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: RegisterUserDtoValidator.cs                       //
/////////////////////////////////////////////////////////////

using FluentValidation;
using OffRoadPortal.Models;
using OffRoadPortal.Services;

namespace OffRoadPortal.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator(OffRoadPortalDbContext dbContext)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password).MinimumLength(8);

        RuleFor(x => x.ConfirmPassword).Equal(p => p.Password);

        RuleFor(x => x.Email)
            .Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(u => u.Email == value);
                if(emailInUse)
                {
                    context.AddFailure("Email", "That email is already used.");
                }
            });
    }
}
