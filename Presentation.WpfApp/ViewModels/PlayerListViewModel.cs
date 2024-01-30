using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WpfApp.ViewModels;

public partial class PlayerListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;

    public PlayerListViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }

    private IEnumerable<FootballPlayerDto> _footballPlayers;
    public IEnumerable<FootballPlayerDto> FootballPlayers
    {
        get { return _footballPlayers; }
        set { SetProperty(ref _footballPlayers, value); }
    }








    [RelayCommand]
    private void NavigateToMenu()
    {
        var mainViewModel = _sp.GetRequiredService<MainWindowViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<MenuViewModel>();
    }
}
