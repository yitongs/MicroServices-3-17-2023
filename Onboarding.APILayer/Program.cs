using Microsoft.EntityFrameworkCore;
using Onboarding.AppliactionCore.Contract.Repository;
using Onboarding.AppliactionCore.Contract.Service;
using Onboarding.Infrastruction.Data;
using Onboarding.Infrastruction.Repository;
using Onboarding.Infrastruction.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<OnboardingDbContext>(option =>
{
    //option.UseSqlServer(builder.Configuration.GetConnectionString("OnboardingApiDbDocker"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("OnboardingApiDbDocker"));
});
builder.Services.AddScoped<IEmployeeRoleRepositoryAsync, EmployeeRoleRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRoleServiceAsync, EmployeeRoleServiceAsync>();
builder.Services.AddScoped<IEmployeeTypeRepositoryAsync, EmployeeTypeRepositoryAsync>();
builder.Services.AddScoped<IEmployeeTypeServiceAsync, EmployeeTypeServiceAsync>();
builder.Services.AddScoped<IEmployeeStatusRepositoryAsync, EmployeeStatusRepositoryAsync>();
builder.Services.AddScoped<IEmployeeStatusServiceAsync, EmployeeStatusServiceAsync>();
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseRouting();//middleware
app.UseEndpoints(endpoint => { endpoint.MapControllers(); });
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();
