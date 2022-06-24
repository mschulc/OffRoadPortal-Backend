/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventCommentController.cs                         //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Dtos;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/event/comment")]
public class EventCommentController : ControllerBase
{
    private readonly IEventCommentService _eventCommentService;

    public EventCommentController(IEventCommentService eventCommentService) 
    {
        _eventCommentService = eventCommentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<EventCommentDto>> GetAll()
    {
        var eventComments = _eventCommentService.GetAll();
        return Ok(eventComments);
    }

    [HttpGet("{id})")]
    public ActionResult<EventCommentDto> GetById([FromRoute] long id)
    {
        var eventComment = _eventCommentService.GetById(id);
        if (eventComment == null) return NotFound();
        return Ok(eventComment);
    }

    [HttpPost]
    public ActionResult CreateEvent([FromBody] CreateEventCommentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdEventCommentId = _eventCommentService.Create(dto);

        return Created($"/event/comment/{createdEventCommentId}", null);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] long id)
    {
        var isDeleted = _eventCommentService.Delete(id);

        if (isDeleted) return NoContent();
        else return NotFound();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromBody] UpdateEventCommentDto dto, [FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = _eventCommentService.Update(id, dto);

        if (!isUpdated) return NotFound();
        return Ok();
    }
}
