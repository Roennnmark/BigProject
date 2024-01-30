using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WpfApp.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;

    public MenuViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }

    [RelayCommand]
    private void NavigateToAddPlayer()
    {
        var mainViewModel = _sp.GetRequiredService<MainWindowViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<PlayerAddViewModel>();
    }
    [RelayCommand]
    private void NavigateToPlayerList()
    {
        var mainViewModel = _sp.GetRequiredService<MainWindowViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<PlayerListViewModel>();
    }
}
