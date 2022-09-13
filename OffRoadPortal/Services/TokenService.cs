/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: TokenService.cs                                   //
/////////////////////////////////////////////////////////////

using Microsoft.IdentityModel.Tokens;
using OffRoadPortal.Authentication;
using OffRoadPortal.Entities;
using OffRoadPortal.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OffRoadPortal.Services;

public class TokenService : ITokenService
{
    private readonly AuthenticationSettings _authenticationSettings;
    private readonly ILogger<TokenService> _logger;

    public TokenService(AuthenticationSettings authenticationSettings, ILogger<TokenService> logger)
    {
        _authenticationSettings = authenticationSettings;
        _logger = logger;
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim("Id", $"{user.Id}"),
            new Claim("FirstName", $"{user.FirstName}"),
            new Claim("LastName", $"{user.LastName}"),
            new Claim("Role", $"{user.Role.Name}"),
            new Claim("Email", user.Email),
            new Claim("BirthDate", user.BirthDate.Value.ToString()),
        };
        if (!string.IsNullOrEmpty(user.ProfileImageUrl))
        {
            claims.Add(new Claim("ProfileImageUrl", user.ProfileImageUrl));
        }
        if (!string.IsNullOrEmpty(user.PhoneNumber))
        {
            claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
        }
        if (!string.IsNullOrEmpty(user.City))
        {
            claims.Add(new Claim("City", user.City));
        }
        if (!(user.Cars is null) || user.Cars?.Count > 0)
        {
            claims.Add(new Claim("Cars", "YES"));
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

        var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
            _authenticationSettings.JwtIssuer, claims,
            expires: expires,
            signingCredentials: cred);
        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}