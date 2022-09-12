/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: FileController.cs                                 //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using OffRoadPortal.Exceptions;
using OffRoadPortal.Interfaces;
using OffRoadPortal.Models;

namespace OffRoadPortal.Controllers;

[Route("file")]
public class FileController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<FileController> _logger;

    public FileController(IUserService userService, ILogger<FileController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost]
    public ActionResult Upload([FromForm]IFormFile file, [FromForm] string rootpath, [FromForm] string userId)
    {
        if(file != null && file.Length > 0)
        {        
            var fullPath = $"{rootpath}/{file.FileName}";
            _logger.LogInformation($"{fullPath}");
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            _userService.UpdateProfileImage(long.Parse(userId), $"/assets/profile/{file.FileName}");
            return Ok(new Response { Status = 200, Name = "Ok", Message = "Upload succeeded" });
        }
        throw new BadRequestException("Upload failed");
    }
}
