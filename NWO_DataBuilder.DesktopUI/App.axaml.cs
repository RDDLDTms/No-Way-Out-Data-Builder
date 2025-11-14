using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NWO_DataBuilder.Core.ViewModels;
using NWO_DataBuilder.DesktopUI.Views;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using System;

namespace NWO_DataBuilder.DesktopUI;

public partial class App : Application
{
    private IServiceProvider Container { get; set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        var appHost = Host
           .CreateDefaultBuilder()
           .ConfigureServices((hostContext, services) =>
           {
               services.UseMicrosoftDependencyResolver();
               var resolver = Locator.CurrentMutable;
               resolver.InitializeSplat();
               resolver.InitializeReactiveUI();
               resolver.RegisterViewsForViewModels(typeof(App).Assembly);
               RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;
               services.ConfigureServices();
           })
           .Build();

        Container = appHost.Services;
        Container.UseMicrosoftDependencyResolver();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = Container.GetRequiredService<MainWindow>();
            desktop.MainWindow.DataContext = Container.GetRequiredService<MainWindowViewModel>();
            desktop.MainWindow.WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
