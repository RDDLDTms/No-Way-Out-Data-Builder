namespace DataBuilder.BuilderObjects.Primal;

/// <summary>
/// Уровень доступности юнита
/// </summary>
public enum AccessLevel
{
    /// <summary>
    /// Вне уровней доступа
    /// </summary>
    None = 0,
    /// <summary>
    /// Доступен на первом уровне
    /// </summary>
    First = 1,
    /// <summary>
    /// Достпуен на втором уровне
    /// </summary>
    Second = 2,
    /// <summary>
    /// Доступен на третьем уровне
    /// </summary>
    Third = 3,
    /// <summary>
    /// Доступен на четвёртом уровне
    /// </summary>
    Fourth = 4,
    /// <summary>
    /// Доступен на пятом уровне
    /// </summary>
    Five = 5,
    /// <summary>
    /// Доступен на шестом уровне
    /// </summary>
    Sixth = 6,
    /// <summary>
    /// Всегда доступен
    /// </summary>
    Always = 100
}
