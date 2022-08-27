/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CreateEventCommentDto.cs                          //
/////////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace OffRoadPortal.Models;

public class CreateEventCommentDto
{
    [Required]
    public string? Author { get; set; }
    public long? UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Content { get; set; }
    public DateTime CreatedDate { get; set; }
}