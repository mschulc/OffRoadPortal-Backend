/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: RegisterUserDto.cs                                //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class RegisterUserDto
{ 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? City { get; set; }
    private string profileImageUrl = "/assets/profile/default.jpg";
    public int RoleId { get; set; } = 1;
    public string ProfileImageUrl { get => profileImageUrl; set => profileImageUrl = value; }
}