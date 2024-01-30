using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Dtos;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Presentation.WpfApp.ViewModels;

public partial class PlayerAddViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly FootballPlayerDto _player;
    private readonly FootballPlayerService _footballPlayerService;

    public PlayerAddViewModel(IServiceProvider sp, FootballPlayerDto player, FootballPlayerService footballPlayerService)
    {
        _sp = sp;
        _player = player;
        _footballPlayerService = footballPlayerService;
    }
    public FootballPlayerDto Player
    {
        get { return _player; }
    }

    [RelayCommand]
    private void NavigateToMenu()
    {
        var mainViewModel = _sp.GetRequiredService<MainWindowViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<MenuViewModel>();
    }

    [RelayCommand]
    private void SavePlayer()
    {
        // Anropa FootballPlayerService för att skapa spelaren i databasen
        bool success = _footballPlayerService.CreateFootballPlayer(_player);

        if (success)
        {
            MessageBox.Show("Spelaren har lagts till i databasen.");
            // Eventuellt återställ eller navigera tillbaka till en annan vy
        }
        else
        {
            MessageBox.Show("Ett fel uppstod när spelaren skulle läggas till.");
        }
    }
}
