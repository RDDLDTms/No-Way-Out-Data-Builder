using DataBuilder.Leverages;
using NWO_Abstractions;

namespace DataBuilder.Units
{
    public class UnitSkill : IUnitSkill
    {
        private Timer? _mainTimer = null;
        private Timer? _additionalTimer = null;

        private ILeverageData _mainData;
        private ILeverageData? _additionalData;
        private LeveragesPriority _priority;

        public LeveragesPriority Priority => _priority;

        public bool CanUseSkill { get; private set; } = true;

        public bool CanUseAdditionalLeverage { get; private set; } = true;

        public ILeverage MainLeverage { get; }

        public ILeverage? AdditionalLeverage { get; }

        public UnitSkill(IUnitLeveragesSource unitLeveragesSource)
        {
            _mainData = unitLeveragesSource.MainData;
            _additionalData = unitLeveragesSource.AdditionalData;
            _priority = unitLeveragesSource.LeveragesPriority;
            MainLeverage = unitLeveragesSource.LeveragesSource.MainLeverage;
            if (unitLeveragesSource.LeveragesSource.AdditionalLeverage is not null)
            {
                _additionalData = unitLeveragesSource.AdditionalData;
                AdditionalLeverage = unitLeveragesSource.LeveragesSource.AdditionalLeverage;
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
            ISkillResultPart? mainPart = GetSkillResultPart(_mainData);
            if (CanUseAdditionalLeverage && _additionalData is not null)
            {
                ISkillResultPart? additionalPart = GetSkillResultPart(_additionalData);
                skillResult = new SkillResult(mainPart!, additionalPart!, _priority);
                RunAdditionalLeverageTimer(battleSpeed);
            }
            else
            {
                skillResult = new SkillResult(mainPart!, _priority);
            }
            return skillResult;
        }

        private ISkillResultPart? GetSkillResultPart(ILeverageData data)
        {
            ISkillResultPart? skillResultPart = null;
            if (data is LeverageHit leverageHit)
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
            _mainTimer = new Timer(new TimerCallback(MainTimerCallback), null, (int)(_mainData.Cooldown * 1000 / battleSpeed), Timeout.Infinite);
        }

        private void RunAdditionalLeverageTimer(double battleSpeed)
        {
            CanUseAdditionalLeverage = false;
            _additionalTimer = new Timer(new TimerCallback(AdditionalTimerCallback), null, (int)(_additionalData!.Cooldown * 1000 / battleSpeed), Timeout.Infinite);
        }

        private void MainTimerCallback(object? state)
        {
            CanUseSkill = true;
            _mainTimer?.Dispose();
            _mainTimer = null;
        }

        private void AdditionalTimerCallback(object? state)
        {
            CanUseAdditionalLeverage = true;
            _additionalTimer?.Dispose();
            _additionalTimer = null;
        }
    }
}
