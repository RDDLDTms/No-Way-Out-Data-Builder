using NWO_Abstractions;
using NWO_Abstractions.Enums;

namespace DataBuilder.Leverages
{
    public class PercentageValues : IPercentageValues
    {
        public PercentageValuesType Type { get; } = PercentageValuesType.None;

        public int AllLeveragesIncrease { get; set; } = 0;

        public int AllLeveragesDecrease { get; set; } = 0;

        public int RecoveryIncrease { get; set; } = 0;

        public int RecoveryDecrease { get; set; } = 0;

        public int DamageIncrease { get; set; } = 0;

        public int DamageDecrease { get; set; } = 0;

        /// <summary>
        /// Получить значение по умолчанию со всеми нулевыми стартовыми процентами
        /// </summary>
        /// <returns>Проентаж по умолчанию (все нули)</returns>
        public static PercentageValues Default() => new();

        public PercentageValues()
        {

        }

        public PercentageValues(PercentageValuesType type)
        {
            Type = type;
        }
    }
}
