using System.Windows;
using AppForNeoStackTechnology.ViewModels;

namespace AppForNeoStackTechnology.Views;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}