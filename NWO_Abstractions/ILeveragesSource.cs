using DataBuilder.BuilderObjects;

namespace NWO_Abstractions;

/// <summary>
/// Истоник воздействий
/// </summary>
public interface ILeveragesSource : IBaseBuilderObject
{
    /// <summary>
    /// Основное воздействие;
    /// </summary>
    public ILeverage MainLeverage { get; set; }

    /// <summary>
    /// Дополнительное воздействие
    /// </summary>
    public ILeverage? AdditionalLeverage { get; set; }

    /// <summary>
    /// Творительный падеж для сообщений (кем/чем)
    /// </summary>
    public string InstrumentalCase { get; }
}

