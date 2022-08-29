/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UserContextService.cs                             //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Interfaces;
using System.Security.Claims;

namespace OffRoadPortal.Services;

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
    public long? GetUserId =>
        User is null ? null : long.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
}