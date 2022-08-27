/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CreateArticleCommentDto.cs                        //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Entities;

namespace OffRoadPortal.Models;

public class CreateArticleCommentDto
{
    public long ArticleId { get; set; }
    public string? Author { get; set; }
    public long? UserId { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedDate { get; set; }
}
