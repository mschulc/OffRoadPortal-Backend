/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventService.cs                                   //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class EventService : IEventService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;

    public EventService(OffRoadPortalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public EventDto GetById(long id)
    {
        var _event = _dbContext.Events.FirstOrDefault(e => e.Id == id);

        if (_event is null) return null;

        var result = _mapper.Map<EventDto>(_event);
        return result;
    }

    public IEnumerable<EventDto> GetAll()
    {
        var events = _dbContext.Events.ToList();

        var result = _mapper.Map<List<EventDto>>(events);

        return result;
    }

    public long Create(CreateEventDto dto)
    {
        var _event = _mapper.Map<Event>(dto);
        _dbContext.Events.Add(_event);
        _dbContext.SaveChanges();
        return _event.Id;
    }

    public bool Delete(long id)
    {
        var _event = _dbContext.Events.FirstOrDefault(e => e.Id == id);

        if(_event is null) return false;

        _dbContext.Events.Remove(_event);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Update(long id, UpdateEventDto dto)
    {
        var _event = _dbContext.Events.FirstOrDefault(e => e.Id == id);

        if (_event is null) return false;

        var result = _mapper.Map<Event>(dto);
        _dbContext.SaveChanges();
        return true;
    }
}
