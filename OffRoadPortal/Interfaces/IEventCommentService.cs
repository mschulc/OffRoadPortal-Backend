/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventCommentService.cs                            //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Dtos;
using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces;

public interface IEventCommentService
{
    long Create(long eventId, CreateEventCommentDto dto);
    void Delete(long eventId, long id);
    List<EventCommentDto> GetAll(long eventId);
    EventCommentDto GetById(long eventId, long id);
    void Update(long eventId, long id, UpdateEventCommentDto dto);
}