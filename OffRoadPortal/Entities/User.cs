/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: User.cs                                           //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Entities;

public class User
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? City { get; set; }
    public string? ProfileImageUrl { get; set; }

    public int RoleId { get; set; }
    public virtual Role? Role { get; set; }
    public virtual List<Car>? Cars { get; set; }
    public virtual List<Event>? Events { get; set; }
}
