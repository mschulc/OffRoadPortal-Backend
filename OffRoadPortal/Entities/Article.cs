/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: Article.cs                                        //
/////////////////////////////////////////////////////////////


namespace OffRoadPortal.Entities;

public class Article
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public long AuthorId { get; set; }
    public string? Author { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public virtual List<ArticleComment>? Comments { get; set; }
}
