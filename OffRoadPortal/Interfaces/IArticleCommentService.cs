/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: IArticleCommentService.cs                         //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Dtos;
using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces;

public interface IArticleCommentService
{
    long Create(CreateArticleCommentDto dto);
    bool Delete(long id);
    IEnumerable<ArticleCommentDto> GetAll();
    ArticleCommentDto GetById(long id);
    bool Update(long id, UpdateArticleCommentDto dto);
}