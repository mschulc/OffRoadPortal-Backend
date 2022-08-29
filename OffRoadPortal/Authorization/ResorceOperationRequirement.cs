/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ResorceOperationRequirement.cs                    //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using OffRoadPortal.Enums;

namespace OffRoadPortal.Authorization;

public class ResorceOperationRequirement : IAuthorizationRequirement
{
    public ResorceOperationRequirement(ResourceOperation resourceOperation)
    {
        ResourceOperation = resourceOperation;
    }

    public ResourceOperation ResourceOperation { get; }
}