using JwtAuthenticationManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("ocelot.json",false,true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCustomJwtAuthentication();

builder.Services.AddCors(option => {
    option.AddDefaultPolicy(o => {

        o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });

});


var app = builder.Build();

await app.UseOcelot();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
