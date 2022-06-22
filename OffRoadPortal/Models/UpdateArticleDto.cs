/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UpdateArticleDto.cs                               //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class UpdateArticleDto
{
    public string? Title { get; set; }
    public string? Content { get; set; }
}
