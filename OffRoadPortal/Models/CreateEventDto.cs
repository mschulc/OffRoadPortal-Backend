/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CreateEventDto.cs                                 //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Enums;
using System.ComponentModel.DataAnnotations;

namespace OffRoadPortal.Models;

public class CreateEventDto
{
    [Required]
    public long EventOrganizerId { get; set; }
    [Required]
    [MaxLength(50)]
    public string? EventName { get; set; }
    public string? EventOrganizer { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? StartEventDate { get; set; }
    public DateTime? EndEventDate { get; set; }
    public string? EventDescription { get; set; }
    public EventCategory Category { get; set; }
    public VehicleType Type { get; set; }
}
