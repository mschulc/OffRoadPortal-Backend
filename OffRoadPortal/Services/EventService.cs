/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventService.cs                                   //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Database;
using OffRoadPortal.Entities;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class EventService : IEventService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<EventService> _logger;

    public EventService(OffRoadPortalDbContext dbContext, IMapper mapper, ILogger<EventService> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public EventDto GetById(long id)
    {
        var _event = GetEventById(id);
        var result = _mapper.Map<EventDto>(_event);
        return result;
    }

    public IEnumerable<EventDto> GetAll()
    {
        var events = _dbContext.Events.ToList();
        if (events is null)
            throw new NotFoundException("Events not found");

        var result = _mapper.Map<List<EventDto>>(events);
        return result;
    }

    public long Create(CreateEventDto dto)
    {
        var _event = _mapper.Map<Event>(dto);
        _dbContext.Events?.Add(_event);
        _dbContext.SaveChanges();
        return _event.Id;
    }

    public void Delete(long id)
    {
        var _event = GetEventById(id);
        _dbContext.Events?.Remove(_event);
        _dbContext.SaveChanges();
    }

    public void Update(long id, UpdateEventDto dto)
    {
        var _event = GetEventById(id);

        _event.EventName = dto.EventName;
        _event.EventDescription = dto.EventDescription;
        _event.StartEventDate = dto.StartEventDate;
        _event.EndEventDate = dto.EndEventDate;
        _event.Category = dto.Category;
        _event.Type = dto.Type;

        _dbContext.Events?.Update(_event);
        _dbContext.SaveChanges();
    }

    private Event GetEventById(long id)
    {
        var _event = _dbContext.Events.FirstOrDefault(e => e.Id == id);
        if (_event is null)
            throw new NotFoundException("Event not found");
        return _event;
    }
}