/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: RegisterUserDtoValidator.cs                       //
/////////////////////////////////////////////////////////////

using FluentValidation;
using OffRoadPortal.Database;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Models;

namespace OffRoadPortal.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator(OffRoadPortalDbContext dbContext)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithState(e => throw new BadRequestException("Email field is incorrect"));

        RuleFor(x => x.Password).NotEmpty().WithState(e => throw new BadRequestException("Password field is empty"));

        RuleFor(x => x.Password)
            .Custom((value, context) =>
        {
            if (value.Length < 8 )
            {
                throw new BadRequestException("Password length must be at least 8");
            }
        });

        RuleFor(x => x).Custom((value, context) => 
        {
            if(value.Password != value.ConfirmPassword)
            {
                throw new BadRequestException("Passwords must be the same");
            }
        });

        RuleFor(x => x.Email)
        .Custom((value, context) =>
        {
            var emailInUse = dbContext.Users.Any(u => u.Email == value);
            if (emailInUse)
            {
                throw new BadRequestException("That email is already used");
            }
        });
    }
}
