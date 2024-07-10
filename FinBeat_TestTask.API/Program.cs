using FastEndpoints;
using FastEndpoints.Swagger;
using FinBeat_TestTask.Infrastructure;
using FinBeat_TestTask.Application;


var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddFastEndpoints()
    .SwaggerDocument();

var application = builder.Build();

application
    .UseFastEndpoints()
    .UseSwaggerGen()
    .UseInfrastructure();

application.Run();
