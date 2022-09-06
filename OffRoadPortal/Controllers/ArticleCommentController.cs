/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleCommentController.cs                       //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/article/{articleId}/comment")]
[Authorize]
public class ArticleCommentController : ControllerBase
{
    private readonly IArticleCommentService _articleCommentService;

    public ArticleCommentController(IArticleCommentService articleCommentService)
    {
        _articleCommentService = articleCommentService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<List<ArticleCommentDto>> GetAll(long articleId)
    {
        var articleComments = _articleCommentService.GetAll(articleId);
        return Ok(articleComments);
    }

    [HttpGet("{id}")]
    public ActionResult<ArticleCommentDto> GetById([FromRoute] long articleId, [FromRoute] long id)
    {
        var articleComment = _articleCommentService.GetById(articleId ,id);
        return Ok(articleComment);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult CreateComment([FromRoute] long articleId, [FromBody] CreateArticleCommentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdArticleCommentId = _articleCommentService.Create(articleId, dto);
        return Created($"/article/{articleId}/comment/{createdArticleCommentId}", null);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public ActionResult Delete([FromRoute] long articleId, [FromRoute] long id)
    {
        _articleCommentService.Delete(articleId, id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromRoute] long articleId, [FromBody] UpdateArticleCommentDto dto, [FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _articleCommentService.Update(articleId, id, dto);
        return Ok();
    }
}