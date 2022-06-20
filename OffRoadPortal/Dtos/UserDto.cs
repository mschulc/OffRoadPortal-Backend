/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UserDto.cs                                        //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Entities;
using OffRoadPortal.Enums;

namespace OffRoadPortal.Dtos;

public class UserDto
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int PhoneNumber { get; set; }
    public int Age { get; set; }
    public UserRole Role { get; set; }
    public string? Description { get; set; }
    public string? Car { get; set; }
    public string? City { get; set; }
    public virtual List<Image>? Images { get; set; }
}
