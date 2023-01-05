using HotChocolate.Types.Descriptors;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;

namespace WebApi.Authorization;

public class CanAccessAttribute : DescriptorAttribute
{
    protected override void TryConfigure(IDescriptorContext context, IDescriptor descriptor, ICustomAttributeProvider element)
    {
        if (descriptor is IObjectTypeDescriptor type)
        {
            type.Directive(new CanAccessDirective());
        }
    }

    internal class CanAccessDirective : DirectiveType
    {
        protected override void Configure(IDirectiveTypeDescriptor descriptor)
        {
            descriptor.Location(DirectiveLocation.Object);
            descriptor.Use(next => async context =>
            {

                var result = await context.Service<IAuthorizationService>().AuthorizeAsync(
                    context.GetUser()!, // User is guaranteed by hTTP interceptor
                    context.Parent<object>(), // Get the object itself that is being retrieved/resolved
                    "CanAccess"
                );

                if (result.Succeeded)
                {
                    await next(context);
                }
                else
                {
                    context.ReportError(
                        ErrorBuilder.New()
                            .SetMessage("User is not authorized")
                            .SetCode(ErrorCodes.Authentication.NotAuthorized)
                            .SetPath(context.Path)
                            .AddLocation(context.Selection.SyntaxNode)
                            .Build()
                    );
                }
            });
        }
    }
}