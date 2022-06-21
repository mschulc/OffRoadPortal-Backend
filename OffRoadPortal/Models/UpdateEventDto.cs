/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UpdateEventDto.cs                                 //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Enums;
using System.ComponentModel.DataAnnotations;

namespace OffRoadPortal.Models;

public class UpdateEventDto
{
    [MaxLength(50)]
    public string? EventName { get; set; }
    public DateTime? StartEventDate { get; set; }
    public DateTime? EndEventDate { get; set; }
    public string? EventDescription { get; set; }
    public EventCategory Category { get; set; }
    public VehicleType Type { get; set; }
}
