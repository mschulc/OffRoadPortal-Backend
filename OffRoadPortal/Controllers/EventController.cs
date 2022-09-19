/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventController.cs                                //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;
using System.Security.Claims;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/event")]
[Authorize]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<IEnumerable<EventDto>> GetAll()
    {
        var events = _eventService.GetAll();
        return Ok(events);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public ActionResult<EventDto> GetById([FromRoute] long id)
    {
        var _event = _eventService.GetById(id);
        return Ok(_event);
    }

    [HttpGet("category/{category}")]
    [AllowAnonymous]
    public ActionResult<EventDto> GetByCategory([FromRoute] int category)
    {
        var _event = _eventService.GetByCategory(category);
        return Ok(_event);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Premium")]
    public ActionResult CreateEvent([FromBody] CreateEventDto dto)
    {
        var userId = long.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
        var createdEventId = _eventService.Create(dto);
        return Created($"/event/{createdEventId}", null);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Premium")]
    public ActionResult Delete([FromRoute] long id)
    {
         _eventService.Delete(id);
         return NoContent();
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin, Premium")]
    public ActionResult Update([FromBody] UpdateEventDto dto, [FromRoute]long id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
         _eventService.Update(id, dto);
        return Ok();
    }

    [HttpPatch("{id}/join/{userId}")]
    [AllowAnonymous]
    public ActionResult Join([FromRoute] long id, [FromRoute] long userId)
    {
        _eventService.Join(id, userId);
        return Ok();
    }

    [HttpPatch("{id}/exit/{userId}")]
    [AllowAnonymous]
    public ActionResult Exit([FromRoute] long id, [FromRoute] long userId)
    {
        _eventService.Exit(id, userId);
        return Ok();
    }
}
