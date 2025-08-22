namespace NWO_Abstractions
{
    public interface ILeverageEffect : IEffect, ILeverageData
    {
        public Timer? EffectTimer { get; }

        public int EffectCounter { get; }

        public ITarget? TargetForEffect { get; }

        public int Duration { get; }
    }
}
