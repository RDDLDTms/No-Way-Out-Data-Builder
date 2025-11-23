namespace NWO_Abstractions.Battles;

public delegate void NewEmptyHandler();
public delegate void NewMessageHandler(string newMessage);
public delegate void NewDoubleHandler(double newValue);
public delegate void EffectHandler(IEffect newEffect, ITarget target);

/// <summary>
/// Моделирование боя
/// </summary>
public interface IBattleModelling : IDisposable
{
    /// <summary>
    /// В бою появляется новый отрицательный эффект на цели
    /// </summary>
    public event EffectHandler OnNewNegativeEffect;

    /// <summary>
    /// С цели пропадает отрицательный эффект
    /// </summary>
    public event EffectHandler OnNegativeEffectEnds;

    /// <summary>
    /// В бою появляется новый отрицательный эффект на цели
    /// </summary>
    public event EffectHandler OnNewPositiveEffect;

    /// <summary>
    /// С цели пропадает положительный эффект
    /// </summary>

    public event EffectHandler OnPositiveEffectEnds;

    /// <summary>
    /// Событие завершения боя
    /// </summary>
    public event NewEmptyHandler OnBattleFinished;

    /// <summary>
    /// Сообщение о новом ударе
    /// </summary>
    public event NewMessageHandler? newActionMessage;

    /// <summary>
    /// Сообщение о начале боя
    /// </summary>
    public event NewMessageHandler? battleStartMessage;

    /// <summary>
    /// Сообщение о завершении боя
    /// </summary>
    public event NewMessageHandler? battleFinishMessage;

    /// <summary>
    /// Изменение оставшегося времени боя
    /// </summary>
    public event NewIntValue? battleTimeLeftChanged;

    /// <summary>
    /// Новое здоровье цели
    /// </summary>
    public event NewDoubleValue? newTargetHealth;

    /// <summary>
    /// Изменение значения всего урона
    /// </summary>
    public event NewIntValue? totalDamage;

    /// <summary>
    /// Изменение значения всего исцеления
    /// </summary>
    public event NewIntValue? totalRecover;

    /// <summary>
    /// Цель битвы
    /// </summary>
    public IBattlePurpose BattlePurpose { get; }

    /// <summary>
    /// Бой остановлен по какой-то причине
    /// </summary>
    public bool BattleStoppedByReason { get; }

    /// <summary>
    /// Отображаемое русское название боя
    /// </summary>
    public string RussianDisplayName { get; }

    /// <summary>
    /// Отображаемое универсальеное имя для боя
    /// </summary>
    public string UniversalDisplayName { get; }

    /// <summary>
    /// Бой начался
    /// </summary>
    public bool Started { get; }

    /// <summary>
    /// Время боя
    /// </summary>
    public int BattleTime { get; }

    /// <summary>
    /// Всего нанесено урона
    /// </summary>
    public int TotalDamage { get; }

    /// <summary>
    /// Всего лечения
    /// </summary>
    public int TotalRecover { get; }

    /// <summary>
    /// Скорость боя
    /// </summary>
    public double BattleSpeed { get; }

    /// <summary>
    /// Времени боя осталось (в секундах)
    /// </summary>
    public int BattleTimeLeft { get; }

    /// <summary>
    /// Те, кто участвует в бою (могут быть целями)
    /// </summary>
    public List<ITarget> Targets { get; set; }

    /// <summary>
    /// Начать бой
    /// </summary>
    /// <returns>Цель боя</returns>
    public void StartBattle();

    /// <summary>
    /// Закончить бой
    /// </summary>
    /// <param name="reason">Причина окончания боя</param>
    /// <returns></returns>
    public void FinishBattle(BattleFinishingReason reason);

    /// <summary>
    /// Получить список противников в бою
    /// </summary>
    /// <param name="teamNumber">Номер команды</param>
    /// <returns>Список противников</returns>
    public List<ITarget> GetEnemies(int teamNumber);

    /// <summary>
    /// Получить список союзников в бою
    /// </summary>
    /// <param name="teamNumber">Номер команды</param>
    /// <returns>Список союзников</returns>
    public List<ITarget> GetAllies(int teamNumber);
}

