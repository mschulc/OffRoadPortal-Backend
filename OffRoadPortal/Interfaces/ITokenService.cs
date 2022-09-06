/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ITokenService.cs                                  //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Entities;

namespace OffRoadPortal.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}