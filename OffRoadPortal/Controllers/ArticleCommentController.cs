/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleCommentController.cs                       //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Dtos;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/article/comment")]
public class ArticleCommentController : ControllerBase
{
    private readonly IArticleCommentService _articleCommentService;

    public ArticleCommentController(IArticleCommentService articleCommentService)
    {
        _articleCommentService = articleCommentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ArticleCommentDto>> GetAll()
    {
        var articleComments = _articleCommentService.GetAll();
        return Ok(articleComments);
    }

    [HttpGet("{id})")]
    public ActionResult<ArticleCommentDto> GetById([FromRoute] long id)
    {
        var articleComment = _articleCommentService.GetById(id);
        if (articleComment == null) return NotFound();
        return Ok(articleComment);
    }

    [HttpPost]
    public ActionResult CreateEvent([FromBody] CreateArticleCommentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdArticleCommentId = _articleCommentService.Create(dto);

        return Created($"/article/comment/{createdArticleCommentId}", null);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] long id)
    {
        var isDeleted = _articleCommentService.Delete(id);

        if (isDeleted) return NoContent();
        else return NotFound();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromBody] UpdateArticleCommentDto dto, [FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = _articleCommentService.Update(id, dto);

        if (!isUpdated) return NotFound();
        return Ok();
    }
}
