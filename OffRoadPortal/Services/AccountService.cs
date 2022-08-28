/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: AccountService.cs                                 //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Identity;
using OffRoadPortal.Database;
using OffRoadPortal.Entities;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class AccountService : IAccountService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AccountService(OffRoadPortalDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    public void RegisterUser(RegisterUserDto dto)
    {
        var newUser = new User()
        {
            Email = dto.Email,
            BirthDate = dto.BirthDate,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            City = dto.City,
            RoleId = dto.RoleId
        };
        var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
        newUser.PasswordHash = hashedPassword;
        _dbContext.Users?.Add(newUser);
        _dbContext.SaveChanges();
    }
}
