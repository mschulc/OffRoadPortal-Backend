/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: IEventService.cs                                  //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Dtos;
using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces
{
    public interface IEventService
    {
        long Create(CreateEventDto dto);
        IEnumerable<EventDto> GetAll();
        EventDto GetById(long id);
        public bool Delete(long id);
        public bool Update(long id, UpdateEventDto dto);
    }
}