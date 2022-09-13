/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UserService.cs                                    //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OffRoadPortal.Authorization;
using OffRoadPortal.Database;
using OffRoadPortal.Entities;
using OffRoadPortal.Enums;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class UserService : IUserService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserContextService _userContextService;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(OffRoadPortalDbContext dbContext, IAuthorizationService authorizationService,
        IUserContextService userContextService, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _authorizationService = authorizationService;
        _userContextService = userContextService;
        _passwordHasher = passwordHasher;
    }

    public void UpdateProfileImage(long id, string path)
    {
        var user = GetUserById(id);
        user.ProfileImageUrl = path;
        _dbContext.Users?.Update(user);
        _dbContext.SaveChanges();
    }

    public void Update(UpdateUserDto dto)
    {
        var user = GetUserById(dto.Id);

        if(dto.PasswordHash == null)
            throw new BadRequestException("Invalid password");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.PasswordHash);
        if (result == PasswordVerificationResult.Failed)
            throw new BadRequestException("Invalid password");

        var authorizationResult = _authorizationService.AuthorizeAsync
            (_userContextService.User, user, new ResorceOperationRequirement(ResourceOperation.Update)).Result;

        if (!authorizationResult.Succeeded)
            throw new FrobidException("The resource is not allowed");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.City = dto.City;
        user.PhoneNumber = dto.PhoneNumber;
        user.BirthDate = dto.BirthDate;

        _dbContext.Users?.Update(user);
        _dbContext.SaveChanges();
    }

    private User GetUserById(long id)
    {
        var user = _dbContext.Users.FirstOrDefault(a => a.Id == id);
        if (user is null)
            throw new NotFoundException("User not found");
        return user;
    }
}