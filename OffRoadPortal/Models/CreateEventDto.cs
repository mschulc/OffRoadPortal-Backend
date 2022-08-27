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

    [Required]
    public DateTime? StartEventDate { get; set; }

    [Required]
    public DateTime? EndEventDate { get; set; }

    [Required]
    public string? EventDescription { get; set; }

    [Required]
    public EventCategory Category { get; set; }

    [Required]
    public VehicleType Type { get; set; }
}
