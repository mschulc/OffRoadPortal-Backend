/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: HelloWorldController.cs                           //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "HelloWorld")]
    public HelloWorld Get()
    {
        return new HelloWorld
        {
            Text = "Hello Offroad!"
        };
    }

    [HttpPost(Name = "HelloWorld")]
    public HelloWorld Post(string text)
    {
        return new HelloWorld { Text = "Witaj " + text };
    }
}


//Test Comment2