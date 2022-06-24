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
    long Create(CreateEventCommentDto dto);
    bool Delete(long id);
    IEnumerable<EventCommentDto> GetAll();
    EventCommentDto GetById(long id);
    bool Update(long id, UpdateEventCommentDto dto);
}