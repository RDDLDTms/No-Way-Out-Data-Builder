using BataBuilder.Items;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Services.BattleLog;
using Splat;

namespace NWO_Battles;

public abstract class BattleBase : IBattleModelling
{
    private Timer? _battleTimer;

    public bool BattleStoppedByReason { get; protected set; }
    
    public string RussianDisplayName { get; }

    public string UniversalDisplayName { get; }

    public int BattleTimeLeft { get; private set; }

    public IBattleSettings BattleSettings { get; }

    public int TotalDamage { get; set; }

    public int TotalRecover { get; set; }

    public BattleFinishingReason BattleFinishingReason { get; protected set; }

    public List<ITarget> Targets { get; set; } = new List<ITarget>();

    public bool Started { get; private set; } = false;

    protected IBattleLogService BattleLogService { get; }

    private double totalBattleDamage = 0;
    private double totalBattleRecover = 0;

    public event NewMessageHandler? newActionMessage;
    public event NewMessageHandler? battleStartMessage;
    public event NewMessageHandler? battleFinishMessage;
    public event NewEmptyHandler? OnBattleFinished;
    public event NewIntValue? battleTimeLeftChanged;
    public event NewTargetHealthValue? newTargetHealth;
    public event NewDoubleValue? totalDamage;
    public event NewDoubleValue? totalRecover;
    public event EffectApplyingHandler OnNewPositiveEffect;
    public event EffectApplyingHandler OnNewNegativeEffect;
    public event EffectApplyingHandler OnNewOtherEffect;
    public event EffectFinishedHandler OnPositiveEffectFinished;
    public event EffectFinishedHandler OnNegativeEffectFinished;
    public event EffectFinishedHandler OnOtherEffectFinished;

    protected Task? timerTask;

    public BattleBase(IBattleSettings settings, string russianDisplayName, string universalDisplayName)
    {
        BattleSettings = settings;
        RussianDisplayName = russianDisplayName;
        UniversalDisplayName = universalDisplayName;
        BattleLogService = Locator.Current.GetService<IBattleLogService>()!;
    }

    public virtual void StartBattle()
    {
        BattleStoppedByReason = false;
        BattleTimeLeft = BattleSettings.BattleTime;
        OnTimeLeftChanged(BattleTimeLeft);
        battleStartMessage?.Invoke(IBattleLogService.BattleBeginningText);
        totalBattleDamage = 0;
        totalBattleRecover = 0;
        totalDamage?.Invoke(totalBattleDamage);
        totalRecover?.Invoke(totalBattleRecover);
        LaunchBattleTimer();
        Started = true;
    }

    public virtual async void FinishBattle(BattleFinishingReason reason)
    {
        await Task.Delay(300);
        BattleStoppedByReason = true;
        while (Targets.Count > 0)
        {
            try
            {
                Targets.Last().LeaveBattle();
            }
            finally
            {

            }
        }

        string message = BattleLogService.GetBattleFinishTextMessage(reason);
        if (reason is BattleFinishingReason.UserStop)
            OnTimeLeftChanged(BattleTimeLeft);
        battleFinishMessage?.Invoke(message);
        OnBattleFinished?.Invoke();
        Started = false;
    }

    protected virtual void OnTargetNegativeEffectFinished(IEffect positiveEffect, ITarget target, EffectFinishReason reason) =>
        OnNegativeEffectFinished?.Invoke(positiveEffect, target, reason);
    protected virtual void OnTargetPositiveEffectFinished(IEffect negativeEffect, ITarget target, EffectFinishReason reason) =>
        OnPositiveEffectFinished?.Invoke(negativeEffect, target, reason);
    protected virtual void OnTargetOtherEffectFinished(IEffect otherEffect, ITarget target, EffectFinishReason reason) =>
        OnOtherEffectFinished?.Invoke(otherEffect, target, reason);

    protected virtual void OnNewTargetPositiveEffect(IEffect positiveEffect, ITarget target) => OnNewPositiveEffect?.Invoke(positiveEffect, target);
    protected virtual void OnNewTargetNegativeEffect(IEffect negativeEffect, ITarget target) => OnNewNegativeEffect?.Invoke(negativeEffect, target);
    protected virtual void OnNewTargetOtherEffect(IEffect otherEffect, ITarget target) => OnNewOtherEffect?.Invoke(otherEffect, target);

    protected virtual void OnNewTargetHealth(double newHealth, ITarget target)
    {   
        newTargetHealth?.Invoke(newHealth, target);
        if (BattleSettings.BattlePurpose is DestroyOneTargetPurpose && newHealth <= 0)
        {
            FinishBattle(BattleFinishingReason.TargetDied);
            return;
        }

        if (BattleSettings.BattlePurpose is RecoverOneOtherTargetPurpose && Targets.Count > 0 && target.MaxHealth <= newHealth)
        {
            if ((target is Dummy && BattleSettings.BattlePurpose.WatchDummy) || (target is not Dummy && BattleSettings.BattlePurpose.WatchDummy is false))
                FinishBattle(BattleFinishingReason.TargetRecovered);
        }
    }

    protected virtual void OnPeriodicEffectTick(IEffect effect, double value, bool isMechTarget)
    {
        switch (effect.Type)
        {
            case EffectType.Positive:
                OnAction(BattleLogService.EffectsLogService.GetPeriodicRecoveringTextMessage(effect.DisplayName, value, effect.LeverageClass.Genitive, isMechTarget));
                break;
            case EffectType.Negative:
                OnAction(BattleLogService.EffectsLogService.GetPeriodicDamageTextMessage(effect.DisplayName, value, effect.LeverageClass.Genitive));
                break;
            case EffectType.None:
            default:
                break;
        }
    }

    protected virtual void OnEffectWithDurationFinished(IEffectWithDuration effect, EffectFinishReason finishReason, ITarget target, string targetDisplayName)
    {
        OnAction(BattleLogService.EffectsLogService.EffectFinished(effect.DisplayName, targetDisplayName, finishReason));
        switch (effect.Type)
        {
            case EffectType.Positive:
                OnTargetPositiveEffectFinished(effect, target, finishReason);
                break;
            case EffectType.Negative:
                OnTargetNegativeEffectFinished(effect, target, finishReason);
                break;
            case EffectType.None:
            default:
                OnTargetOtherEffectFinished(effect, target, finishReason);
                break;
        }
    }

    /// <summary>
    /// Вызов события нового лечения
    /// </summary>
    /// <param name="recover">Величина лечения</param>
    protected virtual void OnNewRecover(double recover)
    {
        totalBattleRecover += recover;
        totalRecover?.Invoke(totalBattleRecover);
    }

    /// <summary>
    /// Вызов события нового урона
    /// </summary>
    /// <param name="damage">Величина урона</param>
    protected virtual void OnNewDamage(double damage)
    {      
        totalBattleDamage += damage;
        totalDamage?.Invoke(totalBattleDamage);
    }

    /// <summary>
    /// Вызов события изменения времени остатка боя
    /// </summary>
    /// <param name="timeLeft">Временна бой осталось (в секундах)</param>
    protected virtual void OnTimeLeftChanged(int timeLeft)
    {
        battleTimeLeftChanged?.Invoke(timeLeft);
    }

    /// <summary>
    /// Вызов события при действии
    /// </summary>
    /// <param name="newMessage">Сообщение об ударе</param>
    protected virtual void OnAction(string newMessage)
    {
        newActionMessage?.Invoke(newMessage);       
    }

    /// <summary>
    /// Запустить таймер битвы
    /// </summary>
    /// <returns></returns>
    protected void LaunchBattleTimer()
    {
        BattleTimeLeft = BattleSettings.BattleTime;
        _battleTimer = new Timer(BattleTimerCallback, null, 1000, (int)(1000 / BattleSettings.BattleSpeed));
    }

    private void BattleTimerCallback(object? state)
    {
        if (BattleStoppedByReason)
        {
            if (_battleTimer is Timer)
            {
                _battleTimer.Dispose();
                _battleTimer = null;
            }
            return;
        }

        BattleTimeLeft--;
        OnTimeLeftChanged(BattleTimeLeft);

        // Кончилось время
        if (BattleTimeLeft <= 0)
        {
            FinishBattle(BattleFinishingReason.TimedOut);
        }

        // Нет ни одной цели
        if (Targets.Count == 0)
        {
            FinishBattle(BattleFinishingReason.NoMoreTargetsFound);
        }

        // Осталась одна команда, но цель убить
        if (BattleSettings.BattlePurpose is DestroyOneTargetPurpose && Targets.DistinctBy(x => x.TeamNumber).Count() <= 1)
        {
            FinishBattle(BattleFinishingReason.NoMoreTargetsFound);
        }
    }

    public abstract void Dispose();

    public List<ITarget> GetEnemies(int teamNumber) => Targets.Where(x => x.TeamNumber != teamNumber).ToList();

    public List<ITarget> GetAllies(int teamNumber) => Targets.Where(x => x.TeamNumber == teamNumber).ToList();
 
}


