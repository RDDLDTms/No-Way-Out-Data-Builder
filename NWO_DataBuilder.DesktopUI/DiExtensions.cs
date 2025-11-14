using Microsoft.Extensions.DependencyInjection;
using NWO_Abstractions.Services;
using NWO_DataBuilder.Core.Models;
using NWO_DataBuilder.Core.Services;
using NWO_DataBuilder.Core.Tests;
using NWO_DataBuilder.Core.ViewModels;
using NWO_DataBuilder.DesktopUI.Views;
using Splat;

namespace NWO_DataBuilder;
public static class DiExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<DictionaryStorage>();
        Locator.CurrentMutable.RegisterLazySingleton(() => new UnitsService(), typeof(IUnitsService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new LeverageService(), typeof(ILeverageService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new LeverageSourcesService(), typeof(ILeveragesSourcesService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new FakeDataBuilder(), typeof(IDictionaryDataLoader));
    }
}
