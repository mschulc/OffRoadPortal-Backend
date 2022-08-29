/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: ResourceOperationRequirementHandler.cs            //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using OffRoadPortal.Entities;
using OffRoadPortal.Enums;
using System.Security.Claims;

namespace OffRoadPortal.Authorization;

public class ResourceOperationRequirementHandler : AuthorizationHandler<ResorceOperationRequirement, Article>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResorceOperationRequirement requirement, Article article)
    {
        if(requirement.ResourceOperation == ResourceOperation.Read || 
            requirement.ResourceOperation == ResourceOperation.Crete)
        {
            context.Succeed(requirement);
        }

        var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
        if (article.AuthorId == long.Parse(userId))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
