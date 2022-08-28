/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: BadRequestException.cs                            //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) {  }
}