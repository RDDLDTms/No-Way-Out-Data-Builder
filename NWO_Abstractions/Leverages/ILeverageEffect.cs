namespace NWO_Abstractions.Leverages
{
    public interface ILeverageEffect : IEffect
    { 
        public Timer? EffectTimer { get; }

        public int EffectCounter { get; }

        public ITarget? TargetForEffect { get; }

        public int Duration { get; }
    }
}
