using System;
using AppForNeoStackTechnology.ViewModels;
using AppForNeoStackTechnology.Views;

namespace AppForNeoStackTechnology;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    /// <summary>
    /// Application Entry for AppForNeoStackTechnology
    /// </summary>
    public App()
    {
        var view = new MainView
        {
            DataContext = Activator.CreateInstance<MainViewModel>()
        };

        view.Show();
    }
}