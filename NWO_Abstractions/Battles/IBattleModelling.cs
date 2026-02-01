using NWO_Abstractions.Effects;

namespace NWO_Abstractions.Battles;

public delegate void NewEmptyHandler();
public delegate void NewMessageHandler(string newMessage);
public delegate void NewTargetHealthValue(double newValue, ITarget target);
public delegate void EffectApplyingHandler(IEffect newEffect, ITarget target);
public delegate void EffectFinishedHandler(IEffect effect, ITarget target, EffectFinishReason reason);

/// <summary>
/// Моделирование боя
/// </summary>
public interface IBattleModelling : IDisposable
{
    /// <summary>
    /// В бою появляется новый отрицательный эффект на цели
    /// </summary>
    public event EffectApplyingHandler OnNewPositiveEffect;
    /// <summary>
    /// В бою появляется новый отрицательный эффект на цели
    /// </summary>
    public event EffectApplyingHandler OnNewNegativeEffect;
    /// <summary>
    /// В бою появляется новый прочий эффект на цели
    /// </summary>
    public event EffectApplyingHandler OnNewOtherEffect;

    /// <summary>
    /// С цели пропадает положительный эффект
    /// </summary>
    public event EffectFinishedHandler OnPositiveEffectFinished;
    /// <summary>
    /// С цели пропадает отрицательный эффект
    /// </summary>
    public event EffectFinishedHandler OnNegativeEffectFinished;
    /// <summary>
    /// С цели пропадает прочий эффект
    /// </summary>
    public event EffectFinishedHandler OnOtherEffectFinished;

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
    public event NewTargetHealthValue? newTargetHealth;

    /// <summary>
    /// Изменение значения всего урона
    /// </summary>
    public event NewDoubleValue? totalDamage;

    /// <summary>
    /// Изменение значения всего исцеления
    /// </summary>
    public event NewDoubleValue? totalRecover;

    /// <summary>
    /// Настройки боя
    /// </summary>
    public IBattleSettings BattleSettings { get; }

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
    /// Всего нанесено урона
    /// </summary>
    public int TotalDamage { get; }

    /// <summary>
    /// Всего лечения
    /// </summary>
    public int TotalRecover { get; }

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

