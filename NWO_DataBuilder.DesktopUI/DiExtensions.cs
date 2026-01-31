using Microsoft.Extensions.DependencyInjection;
using NWO_Abstractions.Services;
using NWO_Abstractions.Services.BattleLog;
using NWO_DataBuilder.Core.LocalImplementations.Services;
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
        Locator.CurrentMutable.RegisterLazySingleton(() => new FakeDataDictionaries(), typeof(IDictionaryDataLoader));
        Locator.CurrentMutable.RegisterLazySingleton(() => new LocalBattleLogService(), typeof(IBattleLogService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new LocalLeverageService(), typeof(ILeverageService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new LocalLeverageSourcesService(), typeof(ILeveragesSourcesService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new LocalEffectsService(), typeof(IEffectsService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new LocalUnitsService(), typeof(IUnitsService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new LocalSkillService(), typeof(ISkillService));
    }
}
