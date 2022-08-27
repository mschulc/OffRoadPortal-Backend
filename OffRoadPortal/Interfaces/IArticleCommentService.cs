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
    long Create(long articleId, CreateArticleCommentDto dto);
    void Delete(long articleId, long id);
    List<ArticleCommentDto> GetAll(long articleId);
    ArticleCommentDto GetById(long articleId, long id);
    void Update(long articleId, long id, UpdateArticleCommentDto dto);
}