using NWO_Abstractions;

namespace DataBuilder.Leverages
{
    public class PercentageValues : IPercentageValues
    {
        public int AllLeveragesIncrease { get; set; } = 0;

        public int AllLeveragesDecrease { get; set; } = 0;

        public int RecoveryIncrease { get; set; } = 0;

        public int RecoveryDecrease { get; set; } = 0;

        public int DamageIncrease { get; set; } = 0;

        public int DamageDecrease { get; set; } = 0;
    }
}
