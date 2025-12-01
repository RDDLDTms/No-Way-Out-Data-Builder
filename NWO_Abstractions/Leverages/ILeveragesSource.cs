using DataBuilder.BuilderObjects;

namespace NWO_Abstractions.Leverages;

/// <summary>
/// Истоник воздействий
/// </summary>
public interface ILeveragesSource : IBaseBuilderObject
{
    /// <summary>
    /// Основное воздействие;
    /// </summary>
    public ILeverage MainLeverage { get; }

    /// <summary>
    /// Дополнительные воздействия
    /// </summary>
    public ILeverage[]? AdditionalLeverages { get; }
}

