using Microsoft.EntityFrameworkCore;
using EvChargingApp.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the DI container
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=applications.db")); // SQLite configuration

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment()) 
{ 
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
} 

// Middleware pipeline
app.UseAuthorization();
app.MapControllers();

app.Run();
