namespace NWO_Abstractions.Enums
{
    /// <summary>
    /// Кому предназначается сообщение
    /// </summary>
    public enum MessageViewer
    {
        /// <summary>
        /// Никому
        /// </summary>
        None = 0,
        /// <summary>
        /// Системное сообщение для разработчика
        /// </summary>
        System = 1,
        /// <summary>
        /// Сообщение для деятеля
        /// </summary>
        Actor = 2,
        /// <summary>
        /// Сообщение для цели
        /// </summary>
        Target = 3,
        /// <summary>
        /// Сообщение и для деятеля и для цели
        /// </summary>
        TargetAndActor = 4,
        /// <summary>
        /// Сообщение для всех
        /// </summary>
        Everyone = 5,
    }
}
