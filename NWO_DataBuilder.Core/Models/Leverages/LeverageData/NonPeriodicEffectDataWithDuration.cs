using DataBuilder.BuilderObjects;

namespace NWO_DataBuilder.Core.Models.Leverages.LeverageData
{
    public sealed class NonPeriodicEffectDataWithDuration : NonPeriodicEffectData, IObjectWithDuration
    {
        public int Duration { get; }

        public int TimeLeft { get; }

        public NonPeriodicEffectDataWithDuration(Guid effectId, int cooldown, int duration) : base(effectId, cooldown)
        {
            Duration = duration;
            TimeLeft = duration;
        }
    }
}
