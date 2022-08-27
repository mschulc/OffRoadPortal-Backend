/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleComment.cs                                 //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Entities;
public class ArticleComment
{
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public long? UserId { get; set; }
    public string? Author { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedDate { get; set; }
}
