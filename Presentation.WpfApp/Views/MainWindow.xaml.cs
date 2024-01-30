using Presentation.WpfApp.ViewModels;
using System.Windows;

namespace Presentation.WpfApp;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}