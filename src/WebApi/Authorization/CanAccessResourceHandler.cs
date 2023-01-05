using Microsoft.AspNetCore.Authorization;
using WebApi.Types;

namespace WebApi.Authorization;

public class CanAccessResourceHandler : AuthorizationHandler<CanAccessResourceRequirement, Item>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanAccessResourceRequirement requirement,
        Item resource)
    {
        // Replace condition with true to succeed on all values
        if (resource.Name != "Bar")
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}