using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NWO_DataBuilder.Core.ViewModels;
using NWO_DataBuilder.DesktopUI.Views;

namespace NWO_DataBuilder.DesktopUI;

public partial class App : Application
{ 
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner,
                DataContext = new MainWindowViewModel()              
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
