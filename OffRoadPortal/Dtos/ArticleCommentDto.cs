/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleCommentDto.cs                              //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Dtos;

public class ArticleCommentDto
{
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public long? UserId { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedDate { get; set; }
}
