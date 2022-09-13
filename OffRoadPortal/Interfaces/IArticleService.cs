/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: IArticleService.cs                                //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Models;
using System.Security.Claims;

namespace OffRoadPortal.Interfaces;

public interface IArticleService
{
    long Create(CreateArticleDto dto);
    void Delete(long id);
    IEnumerable<ArticleDto> GetAll();
    ArticleDto GetById(long id);
    void Update(long id, UpdateArticleDto dto);
    public IEnumerable<ArticleDto> GetAllByAuthorId(long id);
}