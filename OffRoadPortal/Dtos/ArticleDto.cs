/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleDto.cs                                     //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Entities;

namespace OffRoadPortal.Dtos;

public class ArticleDto
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public long AuthorId { get; set; }
    public string? Author { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? ImageUrl { get; set; }
    public virtual List<ArticleComment>? ArticleComments { get; set; }
}
