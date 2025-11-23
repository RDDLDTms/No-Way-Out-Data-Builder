using BataBuilder.Items;
using DataBuilder.Effects;
using DataBuilder.Leverages;
using DataBuilder.Units;
using NWO_Abstractions;
using NWO_Abstractions.Battles;
using NWO_Abstractions.Enums;
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

        public ReadOnlyObservableCollection<BattleTestMessage> MessagesList => _messagesList;

        public ReadOnlyObservableCollection<IUnit> AllUnits => _allUnits;

        public ReadOnlyObservableCollection<IBattlePurpose> AllPurposes => _allPurposes;

        public ViewModelActivator Activator { get; } = new();

        public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit>? StartStopRagerBattleReactiveCommand { get; set; }

        [Reactive] public string StartStopButtonText { get; set; } = BattleBase.StartBattleText;
        [Reactive] public string BattleTimeText { get; set; } = "00:00:00";
        [Reactive] public string TotalDamageText { get; set; } = "0";
        [Reactive] public string TotalRecoverText { get; set; } = "0";
        [Reactive] public string BattleSpeedText { get; set; }
        [Reactive] public bool BattleStarted { get; set; } = false;
        [Reactive] public Unit SelectedUnit { get; set; }
        [Reactive] public IBattlePurpose SelectedPurpose { get; set; }
        [Reactive] public int MaxHealth { get; set; } = 1000;
        [Reactive] public int StartHealth { get; set; } = 1000;
        [Reactive] public int Health { get; set; }
        [Reactive] public int BattleTimeHours { get; set; } = 0;
        [Reactive] public int BattleTimeMinutes { get; set; } = 0;
        [Reactive] public int BattleTimeSeconds { get; set; } = 30;

        #region LeveragesForDummy

        [Reactive] public int AllLeveragesForDummyIncrease { get; set; } = 0;
        [Reactive] public int AllLeveragesForDummyDecrease { get; set; } = 0;
        [Reactive] public int RecoveryForDummyIncrease { get; set; } = 0;
        [Reactive] public int RecoveryForDummyDecrease { get; set; } = 0;
        [Reactive] public int DamageForDummyIncrease { get; set; } = 0;
        [Reactive] public int DamageForDummyDecrease { get; set; } = 0;

        #endregion

        #region UnitLeverages

        [Reactive] public int UnitLeveragesIncreasePercent { get; set; } = 0;
        [Reactive] public int UnitLeveragesDecreasePercent { get; set; } = 0;
        [Reactive] public int UnitDamageIncreasePercent { get; set; } = 0;
        [Reactive] public int UnitDamageDecreasePercent { get; set; } = 0;
        [Reactive] public int UnitRecoveryIncreasePercent { get; set; } = 0;
        [Reactive] public int UnitRecoveryDecreasePercent { get; set; } = 0;
         
        #endregion

        [Reactive] public double BattleSpeed { get; set; } = 1;

        public bool IsAlive { get { return IsImmortal ? true : Health > 0; } set { } }

        [Reactive] public bool IsImmortal { get; set; } = false;

        public BattleUnitVsDummyViewModel()
        {
            _allUnits = new(new ObservableCollection<IUnit>(DictionaryStorage.GetInstance().AllUnits.Values));

            BattleSpeedText = $"{BattleSpeed}x";

            _battleMessages = new ObservableCollection<BattleTestMessage>();
            _messagesList = new ReadOnlyObservableCollection<BattleTestMessage>(_battleMessages);

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
                new RecoverOneTargetPurpose()
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

        private void Battle_totalRecover(int newValue)
        {
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                TotalRecoverText = newValue.ToString();
            });
        }

        private void Battle_totalDamage(int newValue)
        {
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                TotalDamageText = newValue.ToString();
            });
        }

        private void OnTargetHealthChanged(double targetHealth)
        {
            _newHealthValue = targetHealth;
            Task.Run(ChangeHealth);
        }

        private async Task ChangeHealth()
        {
            while (IsAlive)
            {
                RxApp.MainThreadScheduler.Schedule(() =>
                {
                    if (_newHealthValue > Health)
                        Health++;
                    else
                    {
                        if (_newHealthValue < Health)
                            Health--;
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
            int startHealth = MaxHealth < StartHealth ? MaxHealth : StartHealth;

            IPercentageValues unitOutcomingStartPercentageValues = new PercentageValues(PercentageValuesType.Outcoming)
            {
                AllLeveragesDecrease = UnitLeveragesDecreasePercent,
                AllLeveragesIncrease = UnitLeveragesIncreasePercent,
                DamageDecrease = UnitDamageDecreasePercent,
                DamageIncrease = UnitDamageIncreasePercent,
                RecoveryDecrease = UnitRecoveryDecreasePercent,
                RecoveryIncrease = UnitRecoveryIncreasePercent,
            };

            IPercentageValues dummyIncomingStartPercentageValues = new PercentageValues(PercentageValuesType.Incoming)
            {
                AllLeveragesIncrease = AllLeveragesForDummyIncrease,
                AllLeveragesDecrease = AllLeveragesForDummyDecrease,
                DamageDecrease = DamageForDummyDecrease,
                DamageIncrease = DamageForDummyIncrease,
                RecoveryDecrease = RecoveryForDummyDecrease,
                RecoveryIncrease = RecoveryForDummyIncrease,
            };

            RxApp.MainThreadScheduler.Schedule(() =>
            {
                StartStopButtonText = BattleBase.StopBattleText;
                BattleSpeedText = $"{BattleSpeed}x";
                TotalDamageText = "0";
                BattleStarted = true;
            });

            var dummySettings = new DummySettings(IsImmortal, dummyIncomingStartPercentageValues, MaxHealth, StartHealth, EffectsLists.Default(), isOrganic: true, isAlive: true, isMech: false);
            _unitInBattle.StartPercentageValues = unitOutcomingStartPercentageValues;

            OneDummyBattleSettings settings = new()
            {
                Dummy = new Dummy(dummySettings),
                BattleSpeed = BattleSpeed,
                BattleTime = battleTime,
                BattlePurpose = SelectedPurpose,
                Unit = _unitInBattle,
                
            };
            
            if (IsImmortal)
            {
                battle = new UnitVsImmortalDummyBattle(settings);
            }
            else
            {
                RxApp.MainThreadScheduler.Schedule(() =>
                {
                    Health = startHealth;
                    _newHealthValue = startHealth;
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
            battle.OnNegativeEffectEnds += Battle_OnNegativeEffectEnds;
            battle.OnPositiveEffectEnds += Battle_OnPositiveEffectEnds;
            battle.OnBattleFinished += Battle_OnBattleFinished;
            battle.StartBattle();
        }

        private void Battle_OnPositiveEffectEnds(IEffect effect, ITarget target)
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

        private void Battle_OnNegativeEffectEnds(IEffect effect, ITarget target)
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
                        _dummyPositiveEffects.Add(effect);
                    }
                    else
                    {
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
                        _dummyNegativeEffects.Add(effect);
                    }
                    else
                    {
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
                battle.OnNegativeEffectEnds -= Battle_OnNegativeEffectEnds;
                battle.OnNegativeEffectEnds -= Battle_OnNegativeEffectEnds;
                battle.newActionMessage -= ShowBattleMessage;
                battle.Dispose();
                battle = null;
            }
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                StartStopButtonText = BattleBase.StartBattleText;
                BattleStarted = false;
            });
        }

        private void ShowBattleMessage(string newMessage)
        {
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                _battleMessages.Add(new BattleTestMessage(newMessage));
            });
        }

        private Unit _unitInBattle;
        private IBattleModelling? battle;
        private double _newHealthValue;

        private ObservableCollection<IEffect> _dummyNegativeEffects;
        private ObservableCollection<IEffect> _dummyPositiveEffects;
        private ObservableCollection<IEffect> _unitNegativeEffects;
        private ObservableCollection<IEffect> _unitPositiveEffects;

        private ObservableCollection<BattleTestMessage> _battleMessages;
        private ObservableCollection<IBattlePurpose> _purposes;

        private ReadOnlyObservableCollection<BattleTestMessage> _messagesList;
        private ReadOnlyObservableCollection<IUnit> _allUnits;
        private ReadOnlyObservableCollection<IBattlePurpose> _allPurposes;

        private ReadOnlyObservableCollection<IEffect> _dummyPositiveEffectsList;
        private ReadOnlyObservableCollection<IEffect> _dummyNegativeEffectsList;
        private ReadOnlyObservableCollection<IEffect> _unitPositiveEffectsList;
        private ReadOnlyObservableCollection<IEffect> _unitNegativeEffectsList;
    }
}
