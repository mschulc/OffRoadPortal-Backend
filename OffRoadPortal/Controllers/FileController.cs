/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: FileController.cs                                 //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;

namespace OffRoadPortal.Controllers;

[Route("file")]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;

    public FileController(ILogger<FileController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult Upload([FromForm]IFormFile file, [FromForm] string rootpath)
    {
        if(file != null && file.Length > 0)
        {        
            var fullPath = $"{rootpath}/{file.FileName}";
            _logger.LogInformation($"{fullPath}");
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Ok("File uploaded");
        }
        return BadRequest("Upload failed");
    }
}
