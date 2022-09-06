/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleController.cs                              //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;
using System.Security.Claims;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/article")]
[Authorize]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<IEnumerable<ArticleDto>> GetAll()
    {
        var articles = _articleService.GetAll();
        return Ok(articles);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public ActionResult<ArticleDto> GetById([FromRoute] long id)
    {
        var article = _articleService.GetById(id);
        return Ok(article);
    }

    [HttpPost]
    [Authorize(Roles = "Redactor")]
    public ActionResult CreateArticle([FromBody] CreateArticleDto dto)
    {
        var userId = long.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
        var createdArticleId = _articleService.Create(dto);
        return Created($"/article/{createdArticleId}", null);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Redactor")]
    public ActionResult Delete([FromRoute] long id)
    {
         _articleService.Delete(id);
         return NoContent();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, Redactor")]
    public ActionResult Update([FromBody] UpdateArticleDto dto, [FromRoute] long id)
    {
        _articleService.Update(id, dto);
        return Ok();
    }
}