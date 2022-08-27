/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleController.cs                              //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Dtos;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/article")]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ArticleDto>> GetAll()
    {
        var articles = _articleService.GetAll();
        return Ok(articles);
    }

    [HttpGet("{id}")]
    public ActionResult<ArticleDto> GetById([FromRoute] long id)
    {
        var article = _articleService.GetById(id);
        return Ok(article);
    }

    [HttpPost]
    public ActionResult CreateArticle([FromBody] CreateArticleDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdArticleId = _articleService.Create(dto);
        return Created($"/article/{createdArticleId}", null);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] long id)
    {
         _articleService.Delete(id);
         return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromBody] UpdateArticleDto dto, [FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _articleService.Update(id, dto);
        return Ok();
    }
}