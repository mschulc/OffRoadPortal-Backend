/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CreateArticleDto.cs                               //
/////////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace OffRoadPortal.Models;

public class CreateArticleDto
{
    [Required]
    [MaxLength(50)]
    public string? Title { get; set; }

    [Required]
    public string? Content { get; set; }
    public long AuthorId { get; set; }

    [Required]
    public string? Author { get; set; }

    [Required]
    public string? ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
}