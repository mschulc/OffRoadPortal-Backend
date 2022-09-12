/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UpdateUserDto.cs                                  //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class UpdateUserDto
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? City { get; set; }
}
