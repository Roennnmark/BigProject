using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.WpfApp.ViewModels;
using Presentation.WpfApp.Views;
using System.Windows;

namespace Presentation.WpfApp;

public partial class App : Application
{
    private IHost? _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<FootballPlayerService>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddTransient<MenuViewModel>();
                services.AddTransient<MenuView>();
                services.AddTransient<PlayerListViewModel>();
                services.AddTransient<PlayerListView>();
                services.AddTransient<PlayerAddViewModel>();
                services.AddTransient<PlayerAddView>();


            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host!.Start();

        var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

    }

}
