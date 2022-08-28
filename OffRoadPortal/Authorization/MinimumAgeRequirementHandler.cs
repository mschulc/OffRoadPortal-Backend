/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: MinimumAgeRequirementHandler.cs                   //
/////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace OffRoadPortal.Authorization;

public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    private readonly ILogger<MinimumAgeRequirementHandler> _logger;

    public MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger)
    {
        _logger = logger;
    }
    
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var dateBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == "BirthDate").Value);
        var userEmail = context.User.FindFirst(c => c.Type == ClaimTypes.Name).Value;

        _logger.LogInformation($"User: {userEmail} with date of birth: [{dateBirth}]");

        if(dateBirth.AddYears(requirement.MinimumAge) <= DateTime.Today)
        {
            _logger.LogInformation("Authorization succedded");
            context.Succeed(requirement);
        }
        else 
        {
            _logger.LogInformation("Authorization failed");
        }

        return Task.CompletedTask;
    }
}