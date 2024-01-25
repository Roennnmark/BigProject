using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.ConsoleApp.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\BigProject\Infrastructure\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<FootballPlayersRepository>();
    services.AddScoped<FootballClubsRepository>();
    services.AddScoped<NationalitiesRepository>();
    services.AddScoped<PositionsRepository>();
    services.AddScoped<BirthDatesRepository>();
    services.AddScoped<FootballPlayerService>();

    services.AddScoped<MenuService>();

}).Build();

builder.Start();

var menu = builder.Services.GetRequiredService<MenuService>();
menu.ShowMenu();

