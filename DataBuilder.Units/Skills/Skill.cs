using DataBuilder.BuilderObjects;
using NWO_Abstractions;
using NWO_Abstractions.Data.Effects;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Leverages;
using NWO_Abstractions.Leverages.LeverageData;
using NWO_Abstractions.Skills;

namespace DataBuilder.Skills
{
    public class Skill : ISkill
    {
        private Timer? _mainTimer = null;
        private Dictionary<int, Timer>? _additionalTimers = null;

        private ILeverageData _mainLeverageData;
        private ILeverageData[]? _additionalLeveragesData;
        private bool[]? _additionalLeveragesOnCooldowns;
        private SkillPriority _priority;

        public SkillPriority Priority => _priority;

        /// <summary>
        /// Умение в откате
        /// </summary>
        public bool OnCooldown { get; private set; } = false;

        /// <summary>
        /// Умение включено/выключено
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Умение заблокировано
        /// </summary>
        public bool Blocked { get; private set; } = false;

        public ILeverage MainLeverage { get; }

        public ILeverage[]? AdditionalLeverages { get; }

        public Skill(IUnitLeveragesSource unitLeveragesSource, SkillPriority priority)
        {
            _mainLeverageData = unitLeveragesSource.MainLeverageData;
            _additionalLeveragesData = unitLeveragesSource.AdditionalLeveragesData;
            _priority = priority;
            MainLeverage = unitLeveragesSource.LeveragesSource.MainLeverage;
            if (unitLeveragesSource.LeveragesSource.AdditionalLeverages is not null)
            {
                _additionalLeveragesData = unitLeveragesSource.AdditionalLeveragesData;
                AdditionalLeverages = unitLeveragesSource.LeveragesSource.AdditionalLeverages;
                _additionalLeveragesOnCooldowns = new bool[AdditionalLeverages.Length];
            }
        }

        public void ResetCooldowns()
        {
            MainTimerCallback(null);
            AdditionalTimerCallback(null);
            OnCooldown = false;
            if (_additionalLeveragesOnCooldowns is not null)
            {
                for (int i = 0; i < _additionalLeveragesOnCooldowns.Length; i++)
                {
                    _additionalLeveragesOnCooldowns[i] = false;
                }
            }
        }

        public void RestoreCooldowns()
        {
            //TODO сделать метод восстановления откатов для скилла
        }

        public ISkillResult GetSkillResult(double battleSpeed)
        {
            if (((ISkill)this).CanUseSkill is false)
                throw new Exception();

            ISkillResult skillResult;
            if (_mainLeverageData is IObjectWithCooldown cooldownObj)
                RunSkillTimer(battleSpeed, cooldownObj);
            ISkillResultPart? mainPart = GetSkillResultPart(MainLeverage, _mainLeverageData);

            if (_additionalLeveragesData is not null && _additionalLeveragesOnCooldowns is not null)
            {
                List<ISkillResultPart> additionalParts = [];
                for (int i = 0; i < _additionalLeveragesData.Length; i++)
                {
                    if (_additionalLeveragesOnCooldowns[i] is false)
                    {
                        var result = GetSkillResultPart(AdditionalLeverages![i], _additionalLeveragesData[i]);
                        if (result is null)
                            continue;

                        additionalParts.Add(result);
                        RunAdditionalLeverageTimer(battleSpeed, i);
                    }
                }
                skillResult = new SkillResult(mainPart!, additionalParts.ToArray());
            }
            else
            {
                skillResult = new SkillResult(mainPart!);
            }
            return skillResult;
        }

        private ISkillResultPart? GetSkillResultPart(ILeverage leverage, ILeverageData data) =>
            leverage.HasEffects ? 
            GetSkillResultPart((IEffectData)data, leverage.Type, leverage.Effects[0]) : 
            GetSkillResultPart((IInstantLeverageData)data, leverage.Type);

        private ISkillResultPart? GetSkillResultPart(IInstantLeverageData instantData, LeverageType type) =>
            new SkillValuesResultPart(type, instantData.GetValue());

        private ISkillResultPart? GetSkillResultPart(IEffectData effectData, LeverageType type, IEffect effect) => 
            new SkillEffectResultPart(effect!, effectData, type);

        private void RunSkillTimer(double battleSpeed, IObjectWithCooldown cooldownObj)
        {
            OnCooldown = true;
            _mainTimer = new Timer(new TimerCallback(MainTimerCallback), null, (int)(cooldownObj.Cooldown / battleSpeed), Timeout.Infinite);
        }

        private void RunAdditionalLeverageTimer(double battleSpeed, int timerIndex)
        {
            _additionalTimers ??= [];
            _additionalLeveragesOnCooldowns![timerIndex] = true;
            if (_additionalLeveragesData![timerIndex] is not IObjectWithCooldown cooldownObj)
                return;

            try
            { 
                _additionalTimers.Add(timerIndex, new Timer(new TimerCallback(AdditionalTimerCallback), timerIndex, (int)(cooldownObj.Cooldown / battleSpeed), Timeout.Infinite));
            }
            catch (Exception ex)
            {

            }
        }

        private void MainTimerCallback(object? state)
        {
            _mainTimer?.Dispose();
            _mainTimer = null;
            OnCooldown = false;
        }

        private void AdditionalTimerCallback(object? state)
        {
            if (state is null) return;
            int index = (int)state!;
            var timer = _additionalTimers![index];
            _additionalTimers!.Remove(index);
            timer?.Dispose();
            _additionalLeveragesOnCooldowns![index] = false;
        }
    }
}
