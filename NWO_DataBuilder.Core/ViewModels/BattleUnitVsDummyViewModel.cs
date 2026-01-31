using BataBuilder.Items;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Effects;
using NWO_Abstractions.Enums;
using NWO_Abstractions.Services.BattleLog;
using NWO_Battles;
using NWO_DataBuilder.Core.Models;
using NWO_Support;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace NWO_DataBuilder.Core.ViewModels
{
    public class BattleUnitVsDummyViewModel : ViewModelBase, IActivatableViewModel
    {
        public ReadOnlyObservableCollection<IEffect> DummyNegativeEffects => _dummyNegativeEffectsList;

        public ReadOnlyObservableCollection<IEffect> DummyPositiveEffects => _dummyPositiveEffectsList;

        public ReadOnlyObservableCollection<IEffect> UnitPositiveEffects => _unitPositiveEffectsList;

        public ReadOnlyObservableCollection<IEffect> UnitNegativeEffects => _unitNegativeEffectsList;

        public ReadOnlyObservableCollection<BattleTextMessage> MessagesList => _messagesList;

        public ReadOnlyObservableCollection<IUnit> AllUnits => _allUnits;

        public ReadOnlyObservableCollection<IBattlePurpose> AllPurposes => _allPurposes;

        public ViewModelActivator Activator { get; } = new();

        public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit>? StartStopRagerBattleReactiveCommand { get; set; }

        [Reactive] public string StartStopButtonText { get; set; } = IBattleLogService.StartBattleText;

        #region DummySettings

        [Reactive] public DummySettings DummySettings { get; set; } = new DummySettings();

        #endregion

        #region UnitSettings

        [Reactive] public Unit SelectedUnit { get; set; }
        [Reactive] public double SelectedUnitStartHealth { get; set; } = 0;
        [Reactive] public PercentageValues UnitPercentageValues { get; set; } = new PercentageValues(PercentageValuesType.Outcoming);

        #endregion

        #region Battle Settings

        [Reactive] public double BattleSpeed { get; set; } = 1;
        [Reactive] public IBattlePurpose SelectedPurpose { get; set; }
        [Reactive] public int BattleTimeHours { get; set; } = 0;
        [Reactive] public int BattleTimeMinutes { get; set; } = 0;
        [Reactive] public int BattleTimeSeconds { get; set; } = 30;

        #endregion

        #region Battle Process

        [Reactive] public double DummyCurrentHealth { get; set; }
        [Reactive] public double UnitCurrentHealth { get; set; }
        [Reactive] public string BattleTimeText { get; set; } = "00:00:00";
        [Reactive] public string TotalDamageText { get; set; } = "0";
        [Reactive] public string TotalRecoverText { get; set; } = "0";
        [Reactive] public string BattleSpeedText { get; set; }
        [Reactive] public bool BattleStarted { get; set; } = false;

        #endregion

        public bool DummyStillAlive { get { return DummySettings.IsImmortal ? true : DummyCurrentHealth > 0; } set { } }

        public BattleUnitVsDummyViewModel()
        {
            _allUnits = new(new ObservableCollection<IUnit>(DictionaryStorage.GetInstance().AllUnits.Values));

            BattleSpeedText = $"{BattleSpeed}x";

            _battleMessages = new ObservableCollection<BattleTextMessage>();
            _messagesList = new ReadOnlyObservableCollection<BattleTextMessage>(_battleMessages);

            _dummyNegativeEffects = new ObservableCollection<IEffect>();
            _dummyNegativeEffectsList = new ReadOnlyObservableCollection<IEffect>(_dummyNegativeEffects);

            _dummyPositiveEffects = new ObservableCollection<IEffect>();
            _dummyPositiveEffectsList = new ReadOnlyObservableCollection<IEffect>(_dummyPositiveEffects);

            _unitNegativeEffects = new ObservableCollection<IEffect>();
            _unitNegativeEffectsList = new ReadOnlyObservableCollection<IEffect>(_unitNegativeEffects);

            _unitPositiveEffects = new ObservableCollection<IEffect>();
            _unitPositiveEffectsList = new ReadOnlyObservableCollection<IEffect>(_unitPositiveEffects);

            _purposes = new ObservableCollection<IBattlePurpose>
            {
                new DestroyOneTargetPurpose(),
                new RecoverOneOtherTargetPurpose()
            };

            _allPurposes = new ReadOnlyObservableCollection<IBattlePurpose>(_purposes);

            StartStopRagerBattleReactiveCommand = ReactiveCommand.CreateFromTask(StartStopBattle, null, RxApp.MainThreadScheduler);
        }

        private void Battle_battleTimeLeftChanged(int newValue)
        {
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                BattleTimeText = TimeTextConverter.ConvertToText(newValue);
            });
        }

        private void Battle_totalRecover(double newValue)
        {
            var valueText = Math.Round(newValue).ToString();
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                TotalRecoverText = valueText;
            });
        }

        private void Battle_totalDamage(double newValue)
        {
            var valueText = Math.Round(newValue).ToString();
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                TotalDamageText = valueText;
            });
        }

        private void OnTargetHealthChanged(double targetHealth, ITarget target)
        {
            if (target.TargetId == SelectedUnit.TargetId)
            {
                _newUnitHealthValue = targetHealth;
                Task.Run(ChangeUnitHealth);
            }
            else if (target is Dummy)
            {
                _newDummyHealthValue = targetHealth;
                Task.Run(ChangeDummyHealth);
            }
        }

        private async Task ChangeUnitHealth()
        {
            while (UnitCurrentHealth != _newUnitHealthValue)
            {
                RxApp.MainThreadScheduler.Schedule(() =>
                {
                    if (Math.Round(_newUnitHealthValue) > UnitCurrentHealth)
                        UnitCurrentHealth++;
                    else
                    {
                        if (Math.Round(_newUnitHealthValue) < UnitCurrentHealth)
                            UnitCurrentHealth--;
                    }
                });
                await Task.Delay(10);
            }
        }

        private async Task ChangeDummyHealth()
        {
            if (DummyStillAlive is false)
                return;

            while (DummyCurrentHealth != _newDummyHealthValue)
            {
                RxApp.MainThreadScheduler.Schedule(() =>
                {
                    if (Math.Round(_newDummyHealthValue) > DummyCurrentHealth)
                        DummyCurrentHealth++;
                    else
                    {
                        if (Math.Round(_newDummyHealthValue) < DummyCurrentHealth)
                            DummyCurrentHealth--;
                    }
                });
                await Task.Delay(10);
            }
        }

        private Task StartStopBattle()
        {
            if (battle is null)
            {
                if (SelectedUnit is null)
                    return Task.CompletedTask;
                StartBattle();
            }
            else
            {
                StopBattle();
            }
            return Task.CompletedTask;
        }

        private void StopBattle()
        {
            battle!.FinishBattle(BattleFinishingReason.UserStop);
        }

        private void StartBattle()
        {
            _unitInBattle = SelectedUnit;
            double battleSpeed = BattleSpeed;
            int battleTime = TimeTextConverter.ConvertToSeconds(BattleTimeHours, BattleTimeMinutes, BattleTimeSeconds);

            RxApp.MainThreadScheduler.Schedule(() =>
            {
                StartStopButtonText = IBattleLogService.StopBattleText;
                BattleSpeedText = $"{BattleSpeed}x";
                TotalDamageText = "0";
                BattleStarted = true;
            });

            _unitInBattle.StartPercentageValues = UnitPercentageValues;
            _unitInBattle.Health = SelectedUnitStartHealth;

            OneDummyBattleSettings settings = new()
            {
                Dummy = new Dummy(DummySettings),
                BattleSpeed = BattleSpeed,
                BattleTime = battleTime,
                BattlePurpose = SelectedPurpose,
                Unit = _unitInBattle,           
            };
            
            if (DummySettings.IsImmortal)
            {
                battle = new UnitVsImmortalDummyBattle(settings);
            }
            else
            {
                RxApp.MainThreadScheduler.Schedule(() =>
                {
                    DummyCurrentHealth = DummySettings.StartHealth;
                    _newDummyHealthValue = DummySettings.StartHealth;
                    UnitCurrentHealth = SelectedUnitStartHealth;
                    _newUnitHealthValue = SelectedUnitStartHealth;
                });
                battle = new UnitVsMortalDummyBattle(settings);
            }

            battle.battleStartMessage += ShowBattleMessage;
            battle.battleFinishMessage += ShowBattleMessage;
            battle.newActionMessage += ShowBattleMessage;
            battle.battleTimeLeftChanged += Battle_battleTimeLeftChanged;
            battle.totalDamage += Battle_totalDamage;
            battle.totalRecover += Battle_totalRecover;
            battle.newTargetHealth += OnTargetHealthChanged;
            battle.OnNewNegativeEffect += Battle_OnNewNegativeEffect;
            battle.OnNewPositiveEffect += Battle_OnNewPositiveEffect;
            battle.OnNegativeEffectFinished += Battle_OnNegativeEffectFinished;
            battle.OnPositiveEffectFinished += Battle_OnPositiveEffectFinished;
            battle.OnBattleFinished += Battle_OnBattleFinished;
            battle.StartBattle();
        }

        private void Battle_OnPositiveEffectFinished(IEffect effect, ITarget target, EffectFinishReason reason)
        {
            if (_dummyPositiveEffects.Count == 0 && _unitPositiveEffects.Count == 0)
                return;

            RxApp.MainThreadScheduler.Schedule(() =>
            {
                try
                {
                    if (target is Dummy)
                    {
                        _dummyPositiveEffects.Remove(_dummyPositiveEffects.First(x => x.Id == effect.Id));
                    }
                    else
                    {
                        _unitPositiveEffects.Remove(_unitPositiveEffects.First(x => x.Id == effect.Id));
                    }
                }
                catch (Exception ex) 
                { 
                }
            });
        }

        private void Battle_OnNegativeEffectFinished(IEffect effect, ITarget target, EffectFinishReason reason)
        {
            if (_dummyNegativeEffects.Count == 0 && _unitNegativeEffects.Count == 0)
                return;

            RxApp.MainThreadScheduler.Schedule(() =>
            {
                try
                {
                    if (target is Dummy)
                    {
                        _dummyNegativeEffects.Remove(_dummyNegativeEffects.First(x => x.Id == effect.Id));
                    }
                    else
                    {
                        _unitNegativeEffects.Remove(_unitNegativeEffects.First(x => x.Id == effect.Id));
                    }
                }
                catch (Exception ex) 
                { 
                
                }
            });
        }

        private void Battle_OnNewPositiveEffect(IEffect effect, ITarget target)
        {
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                try
                {
                    if (target is Dummy)
                    {
                        if (_dummyPositiveEffects.Contains(effect) is false)
                            _dummyPositiveEffects.Add(effect);
                    }
                    else
                    {
                        if (_unitPositiveEffects.Contains(effect) is false)
                            _unitPositiveEffects.Add(effect);
                    }
                }
                catch (Exception ex)
                {

                }
            });
        }

        private void Battle_OnNewNegativeEffect(IEffect effect, ITarget target)
        {
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                try
                {
                    if (target is Dummy)
                    {
                        if (_dummyNegativeEffects.Contains(effect) is false)
                            _dummyNegativeEffects.Add(effect);
                    }
                    else
                    {   
                        if(_dummyNegativeEffects.Contains(effect) is false)
                            _unitNegativeEffects.Add(effect);
                    }
                }
                catch (Exception ex) 
                { 
                
                }
            });
        }

        private void Battle_OnBattleFinished()
        {
            if (_dummyNegativeEffects is not null)
                _dummyNegativeEffects.Clear();
            if (_dummyPositiveEffects is not null)
                _dummyPositiveEffects.Clear();
            if (_unitNegativeEffects is not null)
                _unitNegativeEffects.Clear();
            if (_unitPositiveEffects is not null)
                _unitPositiveEffects.Clear();

            if (battle is not null)
            {
                battle.battleStartMessage -= ShowBattleMessage;
                battle.battleFinishMessage -= ShowBattleMessage;
                battle.battleTimeLeftChanged -= Battle_battleTimeLeftChanged;
                battle.totalDamage -= Battle_totalDamage;
                battle.totalRecover -= Battle_totalRecover;
                battle.newTargetHealth -= OnTargetHealthChanged;
                battle.OnBattleFinished -= Battle_OnBattleFinished; 
                battle.OnNewNegativeEffect -= Battle_OnNewNegativeEffect;
                battle.OnNewPositiveEffect -= Battle_OnNewPositiveEffect;
                battle.OnNegativeEffectFinished -= Battle_OnNegativeEffectFinished;
                battle.OnNegativeEffectFinished -= Battle_OnNegativeEffectFinished;
                battle.newActionMessage -= ShowBattleMessage;
                battle.Dispose();
                battle = null;
            }
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                StartStopButtonText = IBattleLogService.StartBattleText;
                BattleStarted = false;
            });
        }

        private void ShowBattleMessage(string newMessage)
        {
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                _battleMessages.Add(new BattleTextMessage(newMessage));
            });
        }

        private Unit _unitInBattle;
        private IBattleModelling? battle;
        private double _newDummyHealthValue;
        private double _newUnitHealthValue;

        private ObservableCollection<IEffect> _dummyNegativeEffects;
        private ObservableCollection<IEffect> _dummyPositiveEffects;
        private ObservableCollection<IEffect> _unitNegativeEffects;
        private ObservableCollection<IEffect> _unitPositiveEffects;

        private ObservableCollection<BattleTextMessage> _battleMessages;
        private ObservableCollection<IBattlePurpose> _purposes;

        private ReadOnlyObservableCollection<BattleTextMessage> _messagesList;
        private ReadOnlyObservableCollection<IUnit> _allUnits;
        private ReadOnlyObservableCollection<IBattlePurpose> _allPurposes;

        private ReadOnlyObservableCollection<IEffect> _dummyPositiveEffectsList;
        private ReadOnlyObservableCollection<IEffect> _dummyNegativeEffectsList;
        private ReadOnlyObservableCollection<IEffect> _unitPositiveEffectsList;
        private ReadOnlyObservableCollection<IEffect> _unitNegativeEffectsList;
    }
}
