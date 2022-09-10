/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UserDto.cs                                        //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class UserDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Role { get; set; }
    public string Token { get; set; }
}
