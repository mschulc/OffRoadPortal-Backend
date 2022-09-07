/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: AccountService.cs                                 //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OffRoadPortal.Database;
using OffRoadPortal.Entities;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class AccountService : IAccountService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly ILogger<AccountService> _logger;
    private readonly ITokenService _tokenService;

    public AccountService(OffRoadPortalDbContext dbContext, IPasswordHasher<User> passwordHasher, 
         ILogger<AccountService> logger, ITokenService tokenService)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _logger = logger;
        _tokenService = tokenService;
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
            RoleId = dto.RoleId,
            ProfileImageUrl = dto.ProfileImageUrl
        };
        var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
        newUser.PasswordHash = hashedPassword;
        _dbContext.Users?.Add(newUser);
        _dbContext.SaveChanges();
    }

    public UserTokenDto LoginUser(LoginUserDto dto)
    {
        var user = _dbContext.Users.Include(u => u.Role)
            .FirstOrDefault(u => u.Email == dto.Email);
        if (user is null)
            throw new BadRequestException("Invalid username of password");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if(result == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid username of password");

        var jwtToken = _tokenService.GenerateToken(user);
        return new UserTokenDto { Id = user.Id, Token = jwtToken };
    }
}