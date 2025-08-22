using BataBuilder.Items;
using NWO_Abstractions;
using System.Text;

namespace NWO_Battles;

public abstract class BattleBase : IBattleModelling
{
    private Timer? _battleTimer;

    public const string BattleBeginningText = "Начало боя";
    public const string StartBattleText = "Начать бой!";
    public const string StopBattleText = "Остановить бой";
    public const string BattleStoppedByUserText = "Бой остановлен пользователем";

    public bool BattleStoppedByReason { get; protected set; }
    
    public string RussianDisplayName { get; }

    public string UniversalDisplayName { get; }

    public int BattleTime { get; private set; }

    public int BattleTimeLeft { get; private set; }

    public double BattleSpeed { get; private set; }

    public int TotalDamage { get; set; }

    public int TotalRecover { get; set; }

    public IPurpose BattlePurpose { get; private set; }

    public BattleFinishingReason BattleFinishingReason { get; protected set; }
    public List<ITarget> Targets { get; set; } = new List<ITarget>();

    public bool Started { get; private set; } = false;

    private int totalBattleDamage = 0;
    private int totalBattleRecover = 0;

    public event NewMessageHandler? newActionMessage;
    public event NewMessageHandler? battleStartMessage;
    public event NewMessageHandler? battleFinishMessage;
    public event NewEmptyHandler? OnBattleFinished;
    public event NewIntValue? battleTimeLeftChanged;
    public event NewIntValue? newTargetHealth;
    public event NewIntValue? totalDamage;
    public event NewIntValue? totalRecover;
    public event EffectHandler? OnNewNegativeEffect;
    public event EffectHandler? OnNewPositiveEffect;
    public event EffectHandler? OnNegativeEffectEnds;
    public event EffectHandler? OnPositiveEffectEnds;

    protected Task? timerTask;

    public BattleBase(double battleSpeed, int battleTime, IPurpose purpose, string russianDisplayName, string universalDisplayName)
    {
        BattleSpeed = battleSpeed;
        BattleTime = battleTime;
        BattlePurpose = purpose;
        RussianDisplayName = russianDisplayName;
        UniversalDisplayName = universalDisplayName;
    }

    public virtual void StartBattle()
    {
        BattleStoppedByReason = false;
        BattleTimeLeft = BattleTime;
        OnTimeLeftChanged(BattleTimeLeft);
        battleStartMessage?.Invoke(BattleBeginningText);
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

        string message;
        switch (reason)
        {
            case BattleFinishingReason.TimedOut:
                message = "Бой завершён, время подошло к концу";
                break;
            case BattleFinishingReason.TargetRecovered:
                message = "Бой завершён, цель восстановлена";
                break;
            case BattleFinishingReason.TargetDied:
                message = "Бой завершён, цель уничтожена!";
                break;
            case BattleFinishingReason.AllTargetsDied:
                message = "Бой завершён, все цели уничтожены!";
                break;
            case BattleFinishingReason.NoMoreTargetsFound:
                message = "Бой завершён, актуальных целей для воздействий нет";
                break;
            case BattleFinishingReason.UserStop:
                message = "Бой остановлен пользователем";
                OnTimeLeftChanged(BattleTimeLeft);
                break;
            default:
                message = "Бой завершён по неизвестной причине";
                break;
        }
        battleFinishMessage?.Invoke(message);
        OnBattleFinished?.Invoke();
        Started = false;
    }

    public string BuildActionMessage(string unitRussianName, IUnitLeveragesSource leveragesSource, ISkillResultPart mainPart, ISkillResultPart? additionalPart)
    {
        StringBuilder stringBuilder = new();

        // основная часть сообщения
        string actionSentence = GetSentenseByType(leveragesSource.LeveragesSource.MainLeverage.Class.Type, mainPart.Value);
        stringBuilder.Append($"{unitRussianName} {actionSentence} ");
        if (leveragesSource.LeveragesSource.MainLeverage.Class.Type is LeverageType.NegativeEffectApplying or LeverageType.PositiveEffectApplying)
        {
            var effect = ((ILeverageEffect)leveragesSource.MainData);
            stringBuilder.Append($"\"{effect.EffectName}\" на {effect.Duration} сек.");
        }
        else
        {
            stringBuilder.Append($"{leveragesSource.LeveragesSource.MainLeverage.Class.Genitive} {leveragesSource.LeveragesSource.InstrumentalCase}");
        }

        // дополнительная часть сообщения
        if (additionalPart is not null)
        {
            string additionalSentense = GetSentenseByType(leveragesSource.LeveragesSource.AdditionalLeverage.Class.Type, additionalPart.Value);
            stringBuilder.Append($" и дополнительно {additionalSentense} ");
            if (leveragesSource.LeveragesSource.AdditionalLeverage.Class.Type is LeverageType.NegativeEffectApplying or LeverageType.PositiveEffectApplying)
            {
                var effect = ((ILeverageEffect)leveragesSource.AdditionalData);
                stringBuilder.Append($"\"{effect.EffectName}\" на {effect.Duration} сек.");
            }
        }
        return stringBuilder.ToString();
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

    protected virtual void OnNewTargetHealth(int newHealth, ITarget target)
    {   
        newTargetHealth?.Invoke(newHealth);
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
        if (BattlePurpose is DestroyOneTargetPurpose && Targets.DistinctBy(x => x.TeamNumber).ToList().Count <= 1)
        {
            FinishBattle(BattleFinishingReason.NoMoreTargetsFound);
        }
    }

    private string GetSentenseByType(LeverageType type, double? leverageValue) 
    {
        return type switch
        {
            LeverageType.Damage => $"наносит {leverageValue}",
            LeverageType.Recovery => $"восстанавливает {leverageValue} здоровья с помощью",
            LeverageType.PositiveEffectApplying => "накладывает положительный эффект",
            LeverageType.NegativeEffectApplying => "накладывает отрицательный эффект",
            LeverageType.PositiveEffectRemoval => "снимает положительный эффект",
            LeverageType.NegativeEffectRemoval => "снимает отрицательный эффект",
            LeverageType.Creation => "создаёт",
            _ => $"делает неизвестно что на {leverageValue} единиц",
        };
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


