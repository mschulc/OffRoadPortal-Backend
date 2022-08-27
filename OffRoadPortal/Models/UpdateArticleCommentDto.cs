﻿/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: UpdateArticleCommentDto.cs                        //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class UpdateArticleCommentDto
{
    public string? Content { get; set; }
    public long? UserId { get; set; }
    public string? Author { get; set; }
}
