using Microsoft.EntityFrameworkCore;
using EvChargingApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=applications.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add and configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", corsBuilder =>
    {
        corsBuilder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
    });
});
builder.WebHost.UseUrls("http://*:5051");

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll"); // Apply the CORS policy
app.UseAuthorization();
app.MapControllers();

app.Run();
