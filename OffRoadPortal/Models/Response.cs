/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: Response.cs                                       //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Models;

public class Response
{
    public string? Name {get; set; }
    public int? Status {get; set; }
    public string? Message { get; set; }
}