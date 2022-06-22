/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CreateArticleDto.cs                               //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class CreateArticleDto
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public long AuthorId { get; set; }
    public string? Author { get; set; }
}
