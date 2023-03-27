using Authentication.APILayer.Data;
using Authentication.APILayer.Repository;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<JwtTokenHandler>();
var result = builder.Configuration.GetConnectionString("AuthenticationApi");
builder.Services.AddDbContext<AuthenticationDbContext>(option => {
    if (result != null)
        option.UseSqlServer(result);
    else
        option.UseSqlServer(Environment.GetEnvironmentVariable("AuthenticationApiDbDocker"));
});

builder.Services.AddIdentity<HrmUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationDbContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IAccountRepositoryAsync, AccountRepositoryAsync>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option => {
    option.AddDefaultPolicy(o => {

        o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
