/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventCommentService.cs                            //
/////////////////////////////////////////////////////////////

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Services;

public class EventCommentService : IEventCommentService
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;

    public EventCommentService(OffRoadPortalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public EventCommentDto GetById(long eventId, long id)
    {
        GetEventById(eventId);
        var eventComment = GetEventCommentById(id, eventId);

        var result = _mapper.Map<EventCommentDto>(eventComment);
        return result;
    }

    public List<EventCommentDto> GetAll(long eventId)
    {
        var _event = GetEventById(eventId);
        var result = _mapper.Map<List<EventCommentDto>>(_event.EventComments);
        return result;
    }

    public long Create(long eventId, CreateEventCommentDto dto)
    {
        GetEventById(eventId);
        var eventComment = _mapper.Map<EventComment>(dto);
        _dbContext.EventComments?.Add(eventComment);
        _dbContext.SaveChanges();
        return eventComment.Id;
    }

    public void Delete(long eventId, long id)
    {
        GetEventById(eventId);
        var eventComment = GetEventCommentById(id, eventId);

        _dbContext.EventComments?.Remove(eventComment);
        _dbContext.SaveChanges();
    }

    public void Update(long eventId, long id, UpdateEventCommentDto dto)
    {
        GetEventById(eventId);
        var eventComment = GetEventCommentById(id, eventId);

        eventComment.Content = dto.Content;

        _dbContext.EventComments?.Update(eventComment);
        _dbContext.SaveChanges();
    }

    private Event GetEventById(long eventId)
    {
        var _event = _dbContext.Events.Include(e => e.EventComments).FirstOrDefault(e => e.Id == eventId);
        if (_event is null)
            throw new NotFoundException("Event not found");
        return _event;
    }

    private EventComment GetEventCommentById(long id, long eventId)
    {
        var eventComment = _dbContext.EventComments.FirstOrDefault(ec => ec.Id == id);
        if (eventComment is null || eventComment.EventId != eventId)
            throw new NotFoundException("Event Comment not found");
        return eventComment;
    }
}
