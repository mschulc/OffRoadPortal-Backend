/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: AccountService.cs                                 //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OffRoadPortal.Authentication;
using OffRoadPortal.Database;
using OffRoadPortal.Entities;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OffRoadPortal.Services;

public class AccountService : IAccountService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthenticationSettings _authenticationSettings;

    public AccountService(OffRoadPortalDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _authenticationSettings = authenticationSettings;
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

    public string GenerateJwt(LoginUserDto dto)
    {
        var user = _dbContext.Users.Include(u => u.Role)
            .FirstOrDefault(u => u.Email == dto.Email);

        if(user is null)
        {
            throw new BadRequestException("Invalid username of password");
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
        if(result == PasswordVerificationResult.Failed)
        {
            throw new BadRequestException("Invalid username of password");
        }
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(ClaimTypes.Role, $"{user.Role}"),
            new Claim("BirthDate", user.BirthDate.Value.ToString("dd-MM-yyyy")),
            new Claim("PhoneNumber", user.PhoneNumber),
            new Claim("City", user.City)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
        var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
        var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer,
            claims,
            expires: expires,
            signingCredentials: cred);
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}
