/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventCommentService.cs                            //
/////////////////////////////////////////////////////////////

using AutoMapper;
using OffRoadPortal.Dtos;
using OffRoadPortal.Entities;
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

    public EventCommentDto GetById(long id)
    {
        var eventComment = _dbContext.EventComments.FirstOrDefault(ec => ec.Id == id);

        if (eventComment is null) return null;

        var result = _mapper.Map<EventCommentDto>(eventComment);
        return result;
    }

    public IEnumerable<EventCommentDto> GetAll()
    {
        var eventComments = _dbContext.EventComments.ToList();

        var result = _mapper.Map<List<EventCommentDto>>(eventComments);

        return result;
    }

    public long Create(CreateEventCommentDto dto)
    {
        var eventComment = _mapper.Map<EventComment>(dto);
        _dbContext.EventComments.Add(eventComment);
        _dbContext.SaveChanges();
        return eventComment.Id;
    }

    public bool Delete(long id)
    {
        var eventComment = _dbContext.EventComments.FirstOrDefault(ec => ec.Id == id);

        if (eventComment is null) return false;

        _dbContext.EventComments.Remove(eventComment);
        _dbContext.SaveChanges();
        return true;
    }

    public bool Update(long id, UpdateEventCommentDto dto)
    {
        var eventComment = _dbContext.EventComments.FirstOrDefault(ec => ec.Id == id);

        if (eventComment is null) return false;

        var result = _mapper.Map<EventComment>(dto);
        _dbContext.SaveChanges();
        return true;
    }
}
