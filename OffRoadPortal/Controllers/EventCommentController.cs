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
[Route("/event/{eventId}/comment")]
public class EventCommentController : ControllerBase
{
    private readonly IEventCommentService _eventCommentService;

    public EventCommentController(IEventCommentService eventCommentService) 
    {
        _eventCommentService = eventCommentService;
    }

    [HttpGet]
    public ActionResult<List<EventCommentDto>> GetAll(long eventId)
    {
        var eventComments = _eventCommentService.GetAll(eventId);
        return Ok(eventComments);
    }

    [HttpGet("{id}")]
    public ActionResult<EventCommentDto> GetById([FromRoute] long eventId, [FromRoute] long id)
    {
        var eventComment = _eventCommentService.GetById(eventId, id);
        return Ok(eventComment);
    }

    [HttpPost]
    public ActionResult CreateEvent([FromRoute] long eventId, [FromBody] CreateEventCommentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdEventCommentId = _eventCommentService.Create(eventId, dto);
        return Created($"/event/{eventId}/comment/{createdEventCommentId}", null);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] long eventId, [FromRoute] long id)
    {
        _eventCommentService.Delete(eventId, id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromRoute] long eventId, [FromBody] UpdateEventCommentDto dto, [FromRoute] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _eventCommentService.Update(eventId, id, dto);
        return Ok();
    }
}
