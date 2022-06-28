/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleCommentService.cs                          //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;
using OffRoadPortal.Services;

public class ArticleCommentService : IArticleCommentService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;

    public ArticleCommentService(OffRoadPortalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public ArticleCommentDto GetById(long id)
    {
        var articleComment = _dbContext.ArticleComments.FirstOrDefault(ac => ac.Id == id);

        if (articleComment is null) return null;

        var result = _mapper.Map<ArticleCommentDto>(articleComment);
        return result;
    }

    public IEnumerable<ArticleCommentDto> GetAll()
    {
        var articleComments = _dbContext.ArticleComments.ToList();

        var result = _mapper.Map<List<ArticleCommentDto>>(articleComments);

        return result;
    }

    public long Create(CreateArticleCommentDto dto)
    {
        var articleComment = _mapper.Map<ArticleComment>(dto);
        _dbContext.ArticleComments.Add(articleComment);
        _dbContext.SaveChanges();
        return articleComment.Id;
    }

    public bool Delete(long id)
    {
        var articleComment = _dbContext.ArticleComments.FirstOrDefault(ac => ac.Id == id);

        if (articleComment is null) return false;

        _dbContext.ArticleComments.Remove(articleComment);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Update(long id, UpdateArticleCommentDto dto)
    {
        var articleComment = _dbContext.ArticleComments.FirstOrDefault(ac => ac.Id == id);

        if (articleComment is null) return false;

        _mapper.Map<ArticleComment>(dto);
        _dbContext.SaveChanges();
        return true;
    }
}
