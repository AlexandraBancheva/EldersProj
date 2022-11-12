using EldersGame.Application.Interfaces;
using EldersGame.Application.Services;
using EldersGame.Persistence;
using EldersGame.Persistence.EldersGameDatabase;
using EldersGame.Persistence.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddTransient<IGamesService, GamesService>();
UseMigrator.UseMigrations(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

CreateDatabase.EnsureDatabase(builder.Configuration);
app.UpdateDatabase();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
