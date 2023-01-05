using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using System.Security.Claims;

namespace WebApi;

public class FakeUserHttpRequestInterceptor : DefaultHttpRequestInterceptor
{
    public override ValueTask OnCreateAsync(HttpContext context, IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken)
    {
        context.User = new ClaimsPrincipal(new ClaimsIdentity(Enumerable.Empty<Claim>(), "Fake user"));

        return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
    }
}