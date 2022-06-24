/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: CarController.cs                                  //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Dtos;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("/user/car")]
public class CarController : ControllerBase
{
    public CarController()
    {

    }
}
