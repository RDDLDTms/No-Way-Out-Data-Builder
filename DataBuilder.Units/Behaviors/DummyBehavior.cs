using NWO_Abstractions;
using NWO_Abstractions.Battles;

namespace DataBuilder.Units.Behaviors
{
    public class DummyBehavior : IBehavior, IDisposable
    {
        private Timer? _timer;
        private Dummy _dummy;
        private IBattleModelling _battle;

        public DummyBehavior(Dummy dummy, IBattleModelling battle) 
        { 
            _dummy = dummy;
            _battle = battle;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task Enable(double battleSpeed, int globalCooldown) 
        {
            _timer = new Timer(TimerCallback, null, (int)(3000/battleSpeed), (int)(1000/battleSpeed));
            return Task.CompletedTask;
        }

        private void TimerCallback(object? state)
        {
            if (_battle.Targets.Count(x => x is not Dummy) is 0)
            {
                _dummy.LeaveBattle();
            }
        }
    }
}
