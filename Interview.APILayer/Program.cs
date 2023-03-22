using Interview.ApplicationCore.Contract.Repository;
using Interview.ApplicationCore.Contract.Service;
using Interview.Infrastruction.Data;
using Interview.Infrastruction.Repository;
using Interview.Infrastruction.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<InterviewDbContext>(option =>
{
    //option.UseSqlServer(builder.Configuration.GetConnectionString("InterviewApiDbDocker"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("InterviewApiDbDocker"));
});

builder.Services.AddScoped<IFeedbackRepositoryAsync, FeedbackRepositoryAsync>();
builder.Services.AddScoped<IFeedbackServiceAsync, FeedbackServiceAsync>();
builder.Services.AddScoped<IInterviewTypeRepositoryAsync, InterviewTypeRepositoryAsync>();
builder.Services.AddScoped<IInterviewTypeServiceAsync, InterviewTypeServiceAsync>();
builder.Services.AddScoped<IInterviewerRepositoryAsync, InterviewerRepositoryAsync>();
builder.Services.AddScoped<IInterviewerServiceAsync, InterviewerServiceAsync>();
builder.Services.AddScoped<IInterviewsRepositoryAsync, InterviewsRepositoryAsync>();
builder.Services.AddScoped<IInterviewsServiceAsync, InterviewsServiceAsync>();
builder.Services.AddScoped<IRecruiterRepositoryAsync, RecruiterRepositoryAsync>();
builder.Services.AddScoped<IRecruiterServiceAsync, RecruiterServiceAsync>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();
app.UseAuthentication();
app.UseRouting();//middleware
app.UseCors();
app.UseAuthorization();
app.UseEndpoints(endpoint => { endpoint.MapControllers(); });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
