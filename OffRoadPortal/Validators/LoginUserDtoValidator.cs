/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: LoginUserDtoValidator.cs                          //
/////////////////////////////////////////////////////////////

using FluentValidation;
using OffRoadPortal.Database;
using OffRoadPortal.Models;

namespace OffRoadPortal.Validators;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator(OffRoadPortalDbContext dbContext)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password).MinimumLength(8);
    }
}
