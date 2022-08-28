﻿/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleService.cs                                 //
/////////////////////////////////////////////////////////////

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OffRoadPortal.Authorization;
using OffRoadPortal.Database;
using OffRoadPortal.Entities;
using OffRoadPortal.Enums;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;
using System.Security.Claims;

namespace OffRoadPortal.Services;

public class ArticleService : IArticleService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<ArticleService> _logger;
    private readonly IAuthorizationService _authorizationService;

    public ArticleService(OffRoadPortalDbContext dbContext, IMapper mapper, ILogger<ArticleService> logger, 
        IAuthorizationService authorizationService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
        _authorizationService = authorizationService;
    }

    public ArticleDto GetById(long id)
    {
        var article = GetArticleById(id);
        return _mapper.Map<ArticleDto>(article);
    }

    public IEnumerable<ArticleDto> GetAll()
    {
        var articles = _dbContext.Articles.Include(a => a.ArticleComments).ToList();
        if (articles is null)
            throw new NotFoundException("Articles not found");

        var result = _mapper.Map<List<ArticleDto>>(articles);
        return result;
    }

    public long Create(CreateArticleDto dto, long userId)
    {
        var article = _mapper.Map<Article>(dto);
        article.AuthorId = userId;
        _dbContext.Articles?.Add(article);
        _dbContext.SaveChanges();
        return article.Id;
    }

    public void Delete(long id)
    {
        var article = GetArticleById(id);
        _dbContext.Articles?.Remove(article);
        _dbContext.SaveChanges();
    }

    public void Update(long id, UpdateArticleDto dto, ClaimsPrincipal user)
    {
        var article = GetArticleById(id);

        var authorizationResult = _authorizationService.AuthorizeAsync
            (user, article, new ResorceOperationRequirement(ResourceOperation.Update)).Result;

        if (!authorizationResult.Succeeded)
            throw new FrobidException("The resource is not allowed");

        article.Title = dto.Title;
        article.Content = dto.Content;
        article.ImageUrl = dto.ImageUrl;

        _dbContext.Articles?.Update(article);
        _dbContext.SaveChanges();
    }

    private Article GetArticleById(long id)
    {
        var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id);
        if (article is null)
            throw new NotFoundException("Article not found");
        return article;
    }
}