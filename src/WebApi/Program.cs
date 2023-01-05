using WebApi;
using WebApi.Types;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddGraphQLServer()
    .AddHttpRequestInterceptor<FakeUserHttpRequestInterceptor>()
    .AddQueryType<Query>()
    .AddType<Item>()
    .InitializeOnStartup();

var app = builder.Build();

app.MapGraphQL();
app.MapBananaCakePop();

app.Run();
