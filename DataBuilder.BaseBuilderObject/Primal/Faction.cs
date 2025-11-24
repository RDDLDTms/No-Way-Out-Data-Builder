using System.ComponentModel;

namespace DataBuilder.BuilderObjects.Primal;

/// <summary>
/// Фракция
/// </summary>
public enum Faction
{
    /// <summary>
    /// Военные
    /// </summary>
    [Description("Военные люди")]
    Military,
    /// <summary>
    /// Верующие
    /// </summary>
    [Description("Верующие люди")]
    Faith,
    /// <summary>
    /// Знающие
    /// </summary>
    [Description("Знающие люди")]
    Knowledge,
    /// <summary>
    /// Замещённые
    /// </summary>
    [Description("Замещённые люди")]
    Replaced,
    /// <summary>
    /// Изменённые
    /// </summary>
    [Description("Изменённые люди")]
    Changed,
    /// <summary>
    /// Непокорные
    /// </summary>
    [Description("Непокорные люди")]
    Unruly,
    /// <summary>
    /// Прочие
    /// </summary>
    [Description("Прочие")]
    Other,
    /// <summary>
    /// Отсутствует
    /// </summary>
    [Description("Отсутствует")]
    None,
    /// <summary>
    /// Неизвестная
    /// </summary>
    [Description("Неизвестная")]
    Unknown,
    /// <summary>
    /// Неримкнувшие
    /// </summary>
    [Description("Непримкнувшие")]
    NonAligned
}
