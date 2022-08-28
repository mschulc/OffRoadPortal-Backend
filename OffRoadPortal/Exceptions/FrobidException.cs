/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: FrobidException.cs                                //
/////////////////////////////////////////////////////////////

namespace OffRoadPortal.Exceptions;

public class FrobidException : Exception
{
    public FrobidException(string message) : base(message) { }
}