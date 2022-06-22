/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleService.cs                                 //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services
{
    public class ArticleService : IArticleService
    {
        private readonly OffRoadPortalDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleService(OffRoadPortalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ArticleDto GetById(long id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id);

            if (article is null) return null;

            var result = _mapper.Map<ArticleDto>(article);
            return result;
        }

        public IEnumerable<ArticleDto> GetAll()
        {
            var articles = _dbContext.Advertisements.ToList();

            var result = _mapper.Map<List<ArticleDto>>(articles);

            return result;
        }

        public long Create(CreateArticleDto dto)
        {
            var article = _mapper.Map<Article>(dto);
            _dbContext.Articles.Add(article);
            _dbContext.SaveChanges();
            return article.Id;
        }

        public bool Delete(long id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id);

            if (article is null) return false;

            _dbContext.Articles.Remove(article);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(long id, UpdateArticleDto dto)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id);

            if (article is null) return false;

            var result = _mapper.Map<Article>(dto);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
