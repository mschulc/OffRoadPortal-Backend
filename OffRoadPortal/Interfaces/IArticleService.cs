/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: IArticleService.cs                                //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Dtos;
using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces
{
    public interface IArticleService
    {
        long Create(CreateArticleDto dto);
        bool Delete(long id);
        IEnumerable<ArticleDto> GetAll();
        ArticleDto GetById(long id);
        bool Update(long id, UpdateArticleDto dto);
    }
}