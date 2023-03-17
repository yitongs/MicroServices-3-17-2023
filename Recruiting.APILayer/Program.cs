using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.Infrastruction.Data;
using Recruiting.Infrastruction.Repository;
using Recruiting.Infrastruction.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<RecruitingDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingApiDbDocker"));
    //option.UseSqlServer(Environment.GetEnvironmentVariable("RecruitingApiDbDocker"));
    //option.UseSqlServer(Environment.GetEnvironmentVariable("RecruitingApiAzure"));
    //option.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingApiAzure"));
});


builder.Services.AddScoped<IJobRequirementRepositoryAsync, JobRequirementRepositoryAsync>();
builder.Services.AddScoped<IJobRequirementServiceAsync, JobRequirementServiceAsync>();
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();
builder.Services.AddScoped<ISubmissionRepositoryAsync, SubmissionRepositoryAsync>();
builder.Services.AddScoped<ISubmissionServiceAsync, SubmissionServiceAsync>();
builder.Services.AddScoped<ISubmissionStatusRepositoryAsync, SubmissionStatusRepositoryAsync>();
builder.Services.AddScoped<ISubmissionStatusServiceAsync, SubmissionStatusServiceAsync>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();
app.UseRouting();//middleware
app.UseCors();
app.UseEndpoints(endpoint => { endpoint.MapControllers(); });


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();
