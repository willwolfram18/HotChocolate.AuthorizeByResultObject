using Microsoft.AspNetCore.Authorization;
using WebApi;
using WebApi.Authorization;
using WebApi.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddScoped<IAuthorizationHandler, CanAccessResourceHandler>()
    .AddAuthorization(authorization =>
    {
        authorization.AddPolicy("CanAccess", policy => policy.Requirements.Add(new CanAccessResourceRequirement()));
    });

builder.Services.AddGraphQLServer()
    .AddHttpRequestInterceptor<FakeUserHttpRequestInterceptor>()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddType<Item>()
    .InitializeOnStartup();

var app = builder.Build();

app.UseAuthorization();

app.MapGraphQL();
app.MapBananaCakePop();

app.Run();
