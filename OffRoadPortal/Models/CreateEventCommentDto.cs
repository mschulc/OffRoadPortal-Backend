/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CreateEventCommentDto.cs                          //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Entities;

namespace OffRoadPortal.Models;

public class CreateEventCommentDto
{
    public long EventId { get; set; }
    public long? UserId { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedDate { get; set; }
}
