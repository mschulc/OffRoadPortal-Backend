/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventDto.cs                                       //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Entities;
using OffRoadPortal.Enums;

namespace OffRoadPortal.Dtos;

public class EventDto
{
    public long Id { get; set; }
    public long EventOrganizerId { get; set; }
    public string? EventName { get; set; }
    public string? EventOrganizer { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? StartEventDate { get; set; }
    public DateTime? EndEventDate { get; set; }
    public string? EventDescription { get; set; }
    public EventCategory Category { get; set; }
    public VehicleType Type { get; set; }
    public virtual List<User>? Participants { get; set; }
    public virtual List<EventComment>? Comments { get; set; }
}
