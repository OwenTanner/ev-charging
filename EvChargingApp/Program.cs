using Microsoft.EntityFrameworkCore;
using EvChargingApp.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the DI container
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=applications.db")); // SQLite configuration

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{ 
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
} 

// Middleware pipeline
app.UseAuthorization();
app.MapControllers();

app.Run();
