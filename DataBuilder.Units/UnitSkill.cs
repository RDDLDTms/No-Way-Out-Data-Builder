using NWO_Abstractions;
using NWO_Abstractions.Leverages;

namespace DataBuilder.Units
{
    public class UnitSkill : IUnitSkill
    {
        private Timer? _mainTimer = null;
        private Dictionary<int, Timer>? _additionalTimers = null;

        private ITypefulLeverage _mainLeverageData;
        private ITypefulLeverage[]? _additionalLeveragesData;
        private SkillPriority _priority;

        public SkillPriority Priority => _priority;

        public bool CanUseSkill { get; private set; } = true;

        public Dictionary<int, bool> CanUseAdditionalLeverages { get; private set; } = new();

        public ILeverage MainLeverage { get; }

        public ILeverage[]? AdditionalLeverages { get; }

        public UnitSkill(IUnitLeveragesSource unitLeveragesSource)
        {
            _mainLeverageData = unitLeveragesSource.MainLeverageData;
            _additionalLeveragesData = unitLeveragesSource.AdditionalLeveragesData;
            _priority = unitLeveragesSource.LeveragesPriority;
            MainLeverage = unitLeveragesSource.LeveragesSource.MainLeverage;
            if (unitLeveragesSource.LeveragesSource.AdditionalLeverages is not null)
            {
                _additionalLeveragesData = unitLeveragesSource.AdditionalLeveragesData;
                AdditionalLeverages = unitLeveragesSource.LeveragesSource.AdditionalLeverages;
            }
            CanUseAdditionalLeverages = new Dictionary<int, bool>();
            for (int i = 0; i < AdditionalLeverages!.Length; i++)
            {
                CanUseAdditionalLeverages.Add(i, true);
            }
        }

        public void RefreshCooldowns()
        {
            MainTimerCallback(null);
            AdditionalTimerCallback(null);
        }

        public ISkillResult GetSkillResult(double battleSpeed)
        {
            if (CanUseSkill is false)
                throw new Exception();

            SkillResult skillResult;
            RunSkillTimer(battleSpeed);
            ISkillResultPart? mainPart = GetSkillResultPart(_mainLeverageData);
            if (_additionalLeveragesData is not null)
            {
                List<ISkillResultPart> additionalPart = [];
                for (int i = 0; i < _additionalLeveragesData.Length; i++)
                {
                    if (CanUseAdditionalLeverages[i])
                    {
                        var result = GetSkillResultPart(_additionalLeveragesData[i]);
                        if (result is null)
                            continue;

                        additionalPart.Add(result);
                        RunAdditionalLeverageTimer(battleSpeed, i);
                    }
                }
                skillResult = new SkillResult(mainPart!, additionalPart.ToArray(), _priority);
            }
            else
            {
                skillResult = new SkillResult(mainPart!, _priority);
            }
            return skillResult;
        }

        private ISkillResultPart? GetSkillResultPart(ITypefulLeverage data)
        {
            ISkillResultPart? skillResultPart = null;
            if (data is IInstantLeverage leverageHit)
            {
                skillResultPart = new SkillResultPart(leverageHit.GetValue(), data.Type);
            }
            else if (data is ILeverageEffect leverageEffect)
            {
                skillResultPart = new SkillResultPart(leverageEffect, data.Type);
            }
            return skillResultPart;
        }

        private void RunSkillTimer(double battleSpeed)
        {
            CanUseSkill = false;
            if (_mainLeverageData is not ILeverageWithCooldown levCooldown)
                return;

            _mainTimer = new Timer(new TimerCallback(MainTimerCallback), null, (int)(levCooldown.Cooldown * 1000 / battleSpeed), Timeout.Infinite);
        }

        private void RunAdditionalLeverageTimer(double battleSpeed, int timerIndex)
        {
            _additionalTimers ??= [];
            CanUseAdditionalLeverages[timerIndex] = true;
            if (_additionalLeveragesData![timerIndex] is not ILeverageWithCooldown levCooldown)
                return;

            _additionalTimers.Add(timerIndex, new Timer(new TimerCallback(AdditionalTimerCallback), timerIndex, (int)(levCooldown.Cooldown * 1000 / battleSpeed), Timeout.Infinite));
        }

        private void MainTimerCallback(object? state)
        {
            CanUseSkill = true;
            _mainTimer?.Dispose();
            _mainTimer = null;
        }

        private void AdditionalTimerCallback(object? state)
        {
            if (state is null) return;
            int index = (int)state!;
            CanUseAdditionalLeverages[index] = true;
            var timer = _additionalTimers![index];
            _additionalTimers.Remove(index);
            timer.Dispose();
        }
    }
}
