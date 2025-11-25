using BataBuilder.Items;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Services;
using Splat;

namespace NWO_Battles;

public abstract class BattleBase : IBattleModelling
{
    private Timer? _battleTimer;

    public bool BattleStoppedByReason { get; protected set; }
    
    public string RussianDisplayName { get; }

    public string UniversalDisplayName { get; }

    public int BattleTime { get; private set; }

    public int BattleTimeLeft { get; private set; }

    public double BattleSpeed { get; private set; }

    public int TotalDamage { get; set; }

    public int TotalRecover { get; set; }

    public IBattlePurpose BattlePurpose { get; private set; }

    public BattleFinishingReason BattleFinishingReason { get; protected set; }
    public List<ITarget> Targets { get; set; } = new List<ITarget>();

    public bool Started { get; private set; } = false;

    protected IBattleLogService BattleLogService { get; }

    private int totalBattleDamage = 0;
    private int totalBattleRecover = 0;

    public event NewMessageHandler? newActionMessage;
    public event NewMessageHandler? battleStartMessage;
    public event NewMessageHandler? battleFinishMessage;
    public event NewEmptyHandler? OnBattleFinished;
    public event NewIntValue? battleTimeLeftChanged;
    public event NewTargetHealthValue? newTargetHealth;
    public event NewIntValue? totalDamage;
    public event NewIntValue? totalRecover;
    public event EffectHandler? OnNewNegativeEffect;
    public event EffectHandler? OnNewPositiveEffect;
    public event EffectHandler? OnNegativeEffectEnds;
    public event EffectHandler? OnPositiveEffectEnds;

    protected Task? timerTask;

    public BattleBase(IBattleSettings settings, string russianDisplayName, string universalDisplayName)
    {
        BattleSpeed = settings.BattleSpeed;
        BattleTime = settings.BattleTime;
        BattlePurpose = settings.BattlePurpose;
        RussianDisplayName = russianDisplayName;
        UniversalDisplayName = universalDisplayName;
        BattleLogService = Locator.Current.GetService<IBattleLogService>()!;
    }

    public virtual void StartBattle()
    {
        BattleStoppedByReason = false;
        BattleTimeLeft = BattleTime;
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
            Targets.Last().LeaveBattle();
        }

        string message = BattleLogService.GetBattleFinishTextMessage(reason);
        if (reason is BattleFinishingReason.UserStop)
            OnTimeLeftChanged(BattleTimeLeft);
        battleFinishMessage?.Invoke(message);
        OnBattleFinished?.Invoke();
        Started = false;
    }

    protected virtual void OnTargetNegativeEffectEnds(IEffect positiveEffect, ITarget target)
    {
        OnNegativeEffectEnds?.Invoke(positiveEffect, target);
    }

    protected virtual void OnTargetPositiveEffectEnds(IEffect negativeEffect, ITarget target)
    {
        OnPositiveEffectEnds?.Invoke(negativeEffect, target);
    }

    protected virtual void OnNewTargetPositiveEffect(IEffect positiveEffect, ITarget target)
    {
        OnNewPositiveEffect?.Invoke(positiveEffect, target);
    }

    protected virtual void OnNewTargetNeagetiveEffect(IEffect negativeEffect, ITarget target)
    {
        OnNewNegativeEffect?.Invoke(negativeEffect, target);
    }

    protected virtual void OnNewTargetHealth(double newHealth, ITarget target)
    {   
        newTargetHealth?.Invoke(newHealth, target);
        if (BattlePurpose is DestroyOneTargetPurpose && newHealth <= 0)
        {
            FinishBattle(BattleFinishingReason.TargetDied);
            return;
        }

        if (BattlePurpose is RecoverOneTargetPurpose && Targets.Count >= 1 && target.MaxHealth <= newHealth)
        {
            FinishBattle(BattleFinishingReason.TargetRecovered);
        }
    }
    
    /// <summary>
    /// Вызов события нового лечения
    /// </summary>
    /// <param name="recover">Величина лечения</param>
    protected virtual void OnNewRecover(int recover)
    {
        totalBattleRecover += recover;
        totalRecover?.Invoke(totalBattleRecover);
    }

    /// <summary>
    /// Вызов события нового урона
    /// </summary>
    /// <param name="damage">Величина урона</param>
    protected virtual void OnNewDamage(int damage)
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
        BattleTimeLeft = BattleTime;
        _battleTimer = new Timer(BattleTimerCallback, null, 1000, (int)(1000 / BattleSpeed));
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
        if (BattlePurpose is DestroyOneTargetPurpose && Targets.DistinctBy(x => x.TeamNumber).Count() <= 1)
        {
            FinishBattle(BattleFinishingReason.NoMoreTargetsFound);
        }
    }

    public abstract void Dispose();

    public List<ITarget> GetEnemies(int teamNumber)
    {
        return Targets.Where(x => x.TeamNumber != teamNumber).ToList();
    }

    public List<ITarget> GetAllies(int teamNumber)
    {
        return Targets.Where(x => x.TeamNumber == teamNumber).ToList();
    }
}


