using DataBuilder.TargetSystem;
using DataBuilder.Units.Behaviors;
using NWO_Abstractions;

namespace DataBuilder.Units
{
    public sealed class Dummy : TargetBase
    {
        private DummyBehavior? _behavior;

        public bool IsImmortal { get; }

        public Dummy(List<IImmune> immunes, List<IDefence> defences, int startHealth, int maxHealth, bool isImmortal, IPercentageValues incomingPercentgaeValues) : 
            base(immunes, defences, startHealth, maxHealth, incomingPercentgaeValues)
        {
            IsImmortal = isImmortal;
            RussianDisplayName = IsImmortal ? "Бессмертный манекен" : "Смертный манекен"; 
            UniversalName = IsImmortal ? "Immortal dummy" : "Mortal dummy";
        }

        public override void JoinBattle(IBattleModelling battle, int teamNumber, int globalCooldown, List<IEffect>? negativeEffects, List<IEffect>? positiveEffects)
        {
            base.JoinBattle(battle, teamNumber, globalCooldown, negativeEffects, positiveEffects);
            _behavior = new DummyBehavior(this, battle);
            _behavior.Enable(battle.BattleSpeed, globalCooldown);
        }

        public override void LeaveBattle()
        {
            base.LeaveBattle();
            _behavior?.Dispose();
            _behavior = null;
        }
    }
}
