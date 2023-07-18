using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ArmoryPet.Core.Actions;
using ArmoryPet.Core.Interfaces;
using ArmoryPet.Core.Services;
using ArmoryPet.Infrastructure;
using ArmoryPet.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWarmaneService, WarmaneService>();
builder.Services.AddScoped<IWarmaneClientApi, WarmaneClientApi>();
builder.Services.AddScoped<IDatabaseActionsService, DatabaseActionsService>();

//Register DbContext
builder.Services.AddDbContext<DatabaseContext>(options =>options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));




var app = builder.Build();

// Configure the HTTP request pipeline.
// TEST TEST TEST TEST
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();