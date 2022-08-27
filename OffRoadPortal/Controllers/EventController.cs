/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventController.cs                                //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Dtos;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/event")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<EventDto>> GetAll()
    {
        var events = _eventService.GetAll();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public ActionResult<EventDto> GetById([FromRoute] long id)
    {
        var _event = _eventService.GetById(id);
        return Ok(_event);
    }

    [HttpPost]
    public ActionResult CreateEvent([FromBody] CreateEventDto dto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdEventId = _eventService.Create(dto);
        return Created($"/event/{createdEventId}", null);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] long id)
    {
         _eventService.Delete(id);
         return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromBody] UpdateEventDto dto, [FromRoute]long id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
         _eventService.Update(id, dto);
        return Ok();
    }
}
