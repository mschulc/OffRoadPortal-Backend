/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: AuthenticationSettings.cs                         //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Authentication;

public class AuthenticationSettings
{
    public string? JwtKey { get; set; }
    public string? JwtExpireDays { get; set; }
    public string? JwtIssuer { get; set; }
}