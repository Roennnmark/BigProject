using Infrastructure.Dtos;
using Infrastructure.Services;
using Presentation.WpfApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.WpfApp.Views;

public partial class PlayerAddView : UserControl
{
    private readonly PlayerAddViewModel _viewModel;
    public PlayerAddView(PlayerAddViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
    }


}
