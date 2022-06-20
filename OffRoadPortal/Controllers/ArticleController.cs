/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ArticleController.cs                              //
/////////////////////////////////////////////////////////////


using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Services;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/article")]
public class ArticleController : ControllerBase
{
    private readonly OffRoadPortalDbContext _dbContext;
    private readonly IMapper _mapper;

    public ArticleController(OffRoadPortalDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
}
