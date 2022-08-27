/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: NotFoundException.cs                              //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}