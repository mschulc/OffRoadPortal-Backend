/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: EventController.cs                                //
/////////////////////////////////////////////////////////////

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Entities;
using OffRoadPortal.Services;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/event")]
public class EventController : ControllerBase
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;

    public EventController(OffRoadPortalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Event>> GetAll()
    {
        return null;
    }

}
