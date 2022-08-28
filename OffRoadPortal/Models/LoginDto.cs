/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: LoginDto.cs                                       //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class LoginDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
