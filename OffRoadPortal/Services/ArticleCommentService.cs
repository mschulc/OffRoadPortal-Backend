/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleCommentService.cs                          //
/////////////////////////////////////////////////////////////

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OffRoadPortal.Database;
using OffRoadPortal.Entities;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class ArticleCommentService : IArticleCommentService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;

    public ArticleCommentService(OffRoadPortalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public ArticleCommentDto GetById(long articleId, long id)
    {
        GetArticleById(articleId);
        var articleComment = GetArticleCommentById(id, articleId);
        var result = _mapper.Map<ArticleCommentDto>(articleComment);
        return result;
    }

    public List<ArticleCommentDto> GetAll(long articleId)
    {
        var article = GetArticleById(articleId);
        var result = _mapper.Map<List<ArticleCommentDto>>(article.ArticleComments);
        return result;
    }

    public long Create(long articleId, CreateArticleCommentDto dto)
    {
        GetArticleById(articleId);
        var articleComment = _mapper.Map<ArticleComment>(dto);
        articleComment.ArticleId = articleId;
        _dbContext.ArticleComments?.Add(articleComment);
        _dbContext.SaveChanges();
        return articleComment.Id;
    }

    public void Delete(long articleId, long id)
    {
        GetArticleById(articleId);
        var articleComment = GetArticleCommentById(id, articleId);
        _dbContext.ArticleComments?.Remove(articleComment);
        _dbContext.SaveChanges();
    }

    public void Update(long articleId, long id, UpdateArticleCommentDto dto)
    {
        GetArticleById(articleId);
        var articleComment = GetArticleCommentById(id, articleId);

        articleComment.Content = dto.Content;

        _dbContext.ArticleComments?.Update(articleComment);
        _dbContext.SaveChanges();
    }

    private Article GetArticleById(long articleId)
    {
        var article = _dbContext.Articles.Include(a => a.ArticleComments).FirstOrDefault(a => a.Id == articleId);
        if (article is null)
            throw new NotFoundException("Article not found");
        return article;
    }

    private ArticleComment GetArticleCommentById(long id, long articleId)
    {
        var articleComment = _dbContext.ArticleComments.FirstOrDefault(ac => ac.Id == id);
        if (articleComment is null || articleComment.ArticleId != articleId)
            throw new NotFoundException("Article Comment not found");
        return articleComment;
    }
}
