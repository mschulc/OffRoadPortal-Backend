/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UpdateEventCommentDto.cs                          //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class UpdateEventCommentDto
{
    public long EventId { get; set; }
    public long? UserId { get; set; }
    public string? Content { get; set; }
}
