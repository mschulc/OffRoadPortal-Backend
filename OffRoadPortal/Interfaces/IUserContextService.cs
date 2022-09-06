/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: IUserContextService.cs                            //
/////////////////////////////////////////////////////////////

using System.Security.Claims;

namespace OffRoadPortal.Interfaces
{
    public interface IUserContextService
    {
        public string? GetUserName { get; }
        long? GetUserId { get; }
        ClaimsPrincipal User { get; }
    }
}