using DataBuilder.BuilderObjects.Primal;
using DataBuilder.Effects.IncreaseEffects.EffectsOnTarget;
using DataBuilder.Effects.PeriodicEffects.EffectsOnTarget;
using DataBuilder.Leverages;
using NWO_Abstractions;
using NWO_DataBuilder.Core.Services;

namespace NWO_DataBuilder.Core.Tests
{
    public static class FakeBuilder
    {
        public static IUnit BuildMonk()
        {
            IUnit monkUnit = CreateMonk();
            return monkUnit;
        }

        public static IUnit BuildRager()
        {
            IUnit ragerUnit = CreateRager();
            return ragerUnit;
        }

        public static IUnit BuildPreacher()
        {
            IUnit preacherUnit = CreatePreacher();
            return preacherUnit;
        }

        public static IUnit BuildSowerOfChaos()
        {
            IUnit sowerOfChaosUnit = CreateSowerOfChaos();
            return sowerOfChaosUnit;
        }

        public static IUnit BuildConqueror()
        {
            IUnit conquerorUnit = CreateConqueror();
            return conquerorUnit;
        }

        private static IUnit CreateConqueror()
        {
            IUnit conquerorUnit;
            UnitsService unitsService = new();
            var conquerorLeveragesSources = CreateConquerorLeveragesSources();
            conquerorUnit = unitsService.CreateNewUnit("Conqueror", "Вершитель", false, Faction.Unruly, AccessLevel.Five, 0, new List<Guid>(), conquerorLeveragesSources, new List<IImmune>(), new List<IDefence>(), 700, 700,
                new PercentageValues());
            return conquerorUnit;
        }

        private static IUnit CreateSowerOfChaos()
        {
            IUnit sowerOfChaosUnit;
            UnitsService unitsService = new();
            var sowerOfChaosLeveragesSources = CreateSowerOfChaosLeveragesSources();
            sowerOfChaosUnit = unitsService.CreateNewUnit("SowerOfChaos", "Сеятель хаоса", false, Faction.Knowledge, AccessLevel.Fourth, 0, new List<Guid>(), sowerOfChaosLeveragesSources, new List<IImmune>(), new List<IDefence>(), 450, 450,
                new PercentageValues());
            return sowerOfChaosUnit;
        }

        private static IUnit CreatePreacher()
        {
            IUnit preacherUnit;
            UnitsService unitsService = new();
            var preacherLeveragesSources = CreatePreacherLeveragesSources();
            preacherUnit = unitsService.CreateNewUnit("Preacher", "Проповедник", false, Faction.Faith, AccessLevel.Third, 0, new List<Guid>(), preacherLeveragesSources, new List<IImmune>(), new List<IDefence>(), 95, 95,
                new PercentageValues());
            return preacherUnit;
        }

        private static IUnit CreateRager()
        {
            IUnit ragerUnit;
            UnitsService unitsService = new();
            var ragerLeveragesSources = CreateRagerLeveragesSources();
            ragerUnit = unitsService.CreateNewUnit("Rager", "Яростень", false, Faction.Faith, AccessLevel.Five, 0, new List<Guid>(), ragerLeveragesSources, new List<IImmune>(), new List<IDefence>(), 666, 666,
                new PercentageValues());
            return ragerUnit;
        }

        private static IUnit CreateMonk()
        {
            IUnit monkUnit;
            UnitsService unitsService = new();
            var monkLeveragesSources = CreateMonkLeveragesSources();
            monkUnit = unitsService.CreateNewUnit("Monk", "Монах", false, Faction.Faith, AccessLevel.Second, 0, new List<Guid>(), monkLeveragesSources, new List<IImmune>(), new List<IDefence>(), 70, 70,
                new PercentageValues());
            return monkUnit;
        }

        private static List<IUnitLeveragesSource> CreateConquerorLeveragesSources()
        {
            List<IUnitLeveragesSource> crls = new();
            ILeveragesSourcesService leveragesSourcesService = new LeverageSourcesService();

            ILeverageService leverageService = new LeverageService();
            List<ILeverageClass> leverageClasses = CreateLeverageClasses(leverageService);
            List<ILeverageOption> leverageOptions = CreateLeverageOptions(leverageService);


            //Зеркальный щит
            ILeverage mirrorShieldMain = leverageService.CreateLeverage(
                leverageClasses[1],
                LeverageTargetType.Enemies,
                LeverageHitPoint.FrontLine,
                LeverageRangeType.Melee,
                LeverageTargeting.Many,
                new List<ILeverageOption>() { leverageOptions[1] });
            ILeveragesSource mirrorShield = leveragesSourcesService.CreateLeveragesSource(mirrorShieldMain, null, "Mirror Shield", "Зеркальный щит", "Зеркальный щит наносит физический урон", "зеркальным щитом");
            IUnitLeveragesSource conquerorMirrorShield = leveragesSourcesService.CreateUnitLeverageSource(mirrorShield, LeveragesPriority.HighPriority, new LeverageHit(10, 20, 5, LeverageType.Damage));
            crls.Add(conquerorMirrorShield);

            //Зеркальный доспех
            ILeverage mirrorArmorMain = leverageService.CreateLeverage(
                leverageClasses[0],
                LeverageTargetType.Enemies,
                LeverageHitPoint.FrontLine,
                LeverageRangeType.Melee,
                LeverageTargeting.Many,
                new List<ILeverageOption>() { leverageOptions[1] });
            ILeverage mirrorArmorAdditional = leverageService.CreateLeverage(
                leverageClasses[14],
                LeverageTargetType.Enemies,
                LeverageHitPoint.FrontLine,
                LeverageRangeType.Melee,
                LeverageTargeting.Many,
                new List<ILeverageOption>() { leverageOptions[1] });
            ILeveragesSource mirrorArmor = leveragesSourcesService.CreateLeveragesSource(mirrorArmorMain, mirrorArmorAdditional, "Mirror Armor", "Зеркальный доспех", "Зеркальный доспех давит другую цель", "зеркальным доспехом");
            IUnitLeveragesSource conquerorMirrorArmor = leveragesSourcesService.CreateUnitLeverageSource(mirrorArmor, LeveragesPriority.AdvancedPriority, new LeverageHit(10, 20, 7, LeverageType.Damage), new LeverageHit(5, 10, 7, LeverageType.Damage));
            crls.Add(conquerorMirrorArmor);

            //Клеймор света
            ILeverage claymoreOfLightMain = leverageService.CreateLeverage(
                leverageClasses[15],
                LeverageTargetType.Enemies,
                LeverageHitPoint.Vision,
                LeverageRangeType.Range,
                LeverageTargeting.Single,
                new List<ILeverageOption>() { leverageOptions[2] });
            ILeverage claymoreOfLightAdditional = leverageService.CreateLeverage(
                leverageClasses[16],
                LeverageTargetType.Enemies,
                LeverageHitPoint.Vision,
                LeverageRangeType.Range,
                LeverageTargeting.Single,
                new List<ILeverageOption>() { leverageOptions[2] });
            ILeveragesSource claymoreOfLight = leveragesSourcesService.CreateLeveragesSource(claymoreOfLightMain, claymoreOfLightAdditional, "Claymore of Light", "Клеймор света", "Клеймор света наносит энергетический урон", "клеймором света");
            IUnitLeveragesSource conquerorClaymoreOfLight = leveragesSourcesService.CreateUnitLeverageSource(claymoreOfLight, LeveragesPriority.PrimalPriority, new LeverageHit(20, 40, 8, LeverageType.Damage), new LeverageHit(7, 12, 8, LeverageType.Damage));
            crls.Add(conquerorClaymoreOfLight);

            return crls;
        }

        private static List<IUnitLeveragesSource> CreateSowerOfChaosLeveragesSources()
        {
            List<IUnitLeveragesSource> crls = new();
            ILeveragesSourcesService leveragesSourcesService = new LeverageSourcesService();

            ILeverageService leverageService = new LeverageService();
            List<ILeverageClass> leverageClasses = CreateLeverageClasses(leverageService);
            List<ILeverageOption> leverageOptions = CreateLeverageOptions(leverageService);

            //Барьер
            ILeverage barrierMain = leverageService.CreateLeverage(
                leverageClasses[13],
                LeverageTargetType.Neutral,
                LeverageHitPoint.SpaceAroundTheHit,
                LeverageRangeType.Range,
                LeverageTargeting.Place,
                new List<ILeverageOption> { leverageOptions[7] });
            ILeveragesSource barrier = leveragesSourcesService.CreateLeveragesSource(barrierMain, null, "barrier", "Барьер", "Создаёт", "барьером");
            IUnitLeveragesSource sowerOfChaosBarrier = leveragesSourcesService.CreateUnitLeverageSource(barrier, LeveragesPriority.HighPriority, new LeverageCreation(10, LeverageType.Creation));
            crls.Add(sowerOfChaosBarrier);

            //Вязкая сфера
            ILeverage viscousSphereMain = leverageService.CreateLeverage(
                leverageClasses[7],
                LeverageTargetType.Alias,
                LeverageHitPoint.Vision,
                LeverageRangeType.Range,
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[2] });
            ILeveragesSource viscousSphere = leveragesSourcesService.CreateLeveragesSource(viscousSphereMain, null, "viscousSphere", "Вязкая сфера", "Накладывает позитивный эффект", "вязкой сферой");
            IUnitLeveragesSource sowerOfChaosViscousSphere = leveragesSourcesService.CreateUnitLeverageSource(viscousSphere, LeveragesPriority.AdvancedPriority, new LeverageEffectsApplying(9, LeverageType.PositiveEffectApplying));
            crls.Add(sowerOfChaosViscousSphere);

            //Помешательство
            ILeverage insanityMain = leverageService.CreateLeverage(
                leverageClasses[11],
                LeverageTargetType.Enemies,
                LeverageHitPoint.SpaceAroundUnit,
                LeverageRangeType.Range,
                LeverageTargeting.Place,
                new List<ILeverageOption> { leverageOptions[1] });
            ILeveragesSource insanity = leveragesSourcesService.CreateLeveragesSource(insanityMain, null, "Insanity", "Помешательство", "Накладывает негативный эффект", "помешательством");
            IUnitLeveragesSource sowerOfChaosInsanity = leveragesSourcesService.CreateUnitLeverageSource(insanity, LeveragesPriority.SupportPriority, new LeverageEffectsApplying(11, LeverageType.NegativeEffectApplying));
            crls.Add(sowerOfChaosInsanity);

            //Касание
            ILeverage touchMain = leverageService.CreateLeverage(
                leverageClasses[12],
                LeverageTargetType.Enemies,
                LeverageHitPoint.Vision,
                LeverageRangeType.Melee,
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[1] });
            ILeverage touchAdditional = leverageService.CreateLeverage(
                leverageClasses[4],
                LeverageTargetType.Alias,
                LeverageHitPoint.Vision,
                LeverageRangeType.Range,
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[2] });
            ILeveragesSource touch = leveragesSourcesService.CreateLeveragesSource(touchMain, touchAdditional, "Touch", "Касание", "Наносит урон в ближнем бою", "касанием");
            IUnitLeveragesSource sowerOfChaosTouch = leveragesSourcesService.CreateUnitLeverageSource(touch, LeveragesPriority.PrimalPriority, new LeverageHit(10, 20, 8, LeverageType.Damage), new LeverageHit(10, 20, 8, LeverageType.Recovery));
            crls.Add(sowerOfChaosTouch);

            //Очищение
            ILeverage purifyingRitualMain = leverageService.CreateLeverage(
                leverageClasses[5],
                LeverageTargetType.Alias,
                LeverageHitPoint.SpaceAroundTheHit,
                LeverageRangeType.Range,
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[6], leverageOptions[7] });
            ILeveragesSource purifyingRitual = leveragesSourcesService.CreateLeveragesSource(purifyingRitualMain, null, "Purifying ritual", "Ритуал очищения", "Снимает негативные эффекты с юнитов в области", "ритуалом очищения");
            IUnitLeveragesSource sowerOfChaosPurifyuingRitual = leveragesSourcesService.CreateUnitLeverageSource(purifyingRitual, LeveragesPriority.BasePriority, new LeverageEffectsRemoval(12, LeverageType.NegativeEffectRemoval));
            crls.Add(sowerOfChaosPurifyuingRitual);

            return crls;
        }

        private static List<IUnitLeveragesSource> CreateMonkLeveragesSources()
        {
            List<IUnitLeveragesSource> crls = new();
            ILeveragesSourcesService leveragesSourcesService = new LeverageSourcesService();

            ILeverageService leverageService = new LeverageService();
            List<ILeverageClass> leverageClasses = CreateLeverageClasses(leverageService);
            List<ILeverageOption> leverageOptions = CreateLeverageOptions(leverageService);

            // неложение защиты
            ILeverage defenceMain = leverageService.CreateLeverage(
                leverageClasses[7],
                LeverageTargetType.Alias,
                LeverageHitPoint.Vision,
                LeverageRangeType.Range,
                LeverageTargeting.Single, new List<ILeverageOption>() { leverageOptions[5] });
            ILeveragesSource defence = leveragesSourcesService.CreateLeveragesSource(defenceMain, null, "Defence", "Защита", "Накладывает эффект защиты", string.Empty);
            IUnitLeveragesSource monkDefence = leveragesSourcesService.CreateUnitLeverageSource(
                defence,
                LeveragesPriority.HighPriority,
                new TargetDefenceIncreaseEffect(7, defence.MainLeverage.Class, 10, "Защита", 30));

            crls.Add(monkDefence);

            // слово лекаря
            ILeverage wordOfHealerMain = leverageService.CreateLeverage(
                leverageClasses[4], 
                LeverageTargetType.Alias, 
                LeverageHitPoint.Vision, 
                LeverageRangeType.Range, 
                LeverageTargeting.Single, new List<ILeverageOption>() { leverageOptions[5] });
            ILeveragesSource wordOfHealer = leveragesSourcesService.CreateLeveragesSource(wordOfHealerMain, null, "Word of healer", "Слово лекаря", "Слово лекаря исцеляет цель", "словом лекаря");
            IUnitLeveragesSource monkWordOfHealer = leveragesSourcesService.CreateUnitLeverageSource(wordOfHealer, LeveragesPriority.BasePriority, new LeverageHit(15, 19, 2, LeverageType.Recovery));
            crls.Add(monkWordOfHealer);
            
            // периодическое исцеление
            ILeverage blessMain = leverageService.CreateLeverage(
                leverageClasses[6],
                LeverageTargetType.Alias,
                LeverageHitPoint.Vision,
                LeverageRangeType.Range,
                LeverageTargeting.Single, new List<ILeverageOption>() { leverageOptions[6] });

            ILeveragesSource bless = leveragesSourcesService.CreateLeveragesSource(blessMain, null, "Bless", "Благо", "Накладывает эффект периодического исцеления", "периодическим исцелением");
            IUnitLeveragesSource monkBless = leveragesSourcesService.CreateUnitLeverageSource(
                bless, 
                LeveragesPriority.AdvancedPriority, 
                new TargetPeriodicRecoveryEffect(6, bless.MainLeverage.Class, 8, "Благо", 4, 7));

            crls.Add(monkBless);

            // очищение
            ILeverage purifyingRitualMain = leverageService.CreateLeverage(
                leverageClasses[5], 
                LeverageTargetType.Alias, 
                LeverageHitPoint.SpaceAroundTheHit, 
                LeverageRangeType.Range, 
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[6], leverageOptions[7] });
            ILeveragesSource purifyingRitual = leveragesSourcesService.CreateLeveragesSource(purifyingRitualMain, null, "Purifying ritual", "Ритуал очищения", "Снимает негативные эффекты с юнитов в области", "ритуалом очищения");
            IUnitLeveragesSource monkPurifyuingRitual = leveragesSourcesService.CreateUnitLeverageSource(purifyingRitual, LeveragesPriority.SupportPriority, new LeverageEffectsRemoval(10, LeverageType.NegativeEffectRemoval));
            crls.Add(monkPurifyuingRitual);

            return crls;
        }

        private static List<IUnitLeveragesSource> CreatePreacherLeveragesSources()
        {
            List<IUnitLeveragesSource> crls = new();
            ILeveragesSourcesService leveragesSourcesService = new LeverageSourcesService();

            ILeverageService leverageService = new LeverageService();
            List<ILeverageClass> leverageClasses = CreateLeverageClasses(leverageService);
            List<ILeverageOption> leverageOptions = CreateLeverageOptions(leverageService);

            // слово проповедника
            ILeverage wordOfPreacherMain = leverageService.CreateLeverage(
                leverageClasses[11],
                LeverageTargetType.Enemies,
                LeverageHitPoint.SpaceAroundUnit,
                LeverageRangeType.Range,
                LeverageTargeting.Place,
                new List<ILeverageOption>() { leverageOptions[5] });
            ILeveragesSource wordOfPreacher = leveragesSourcesService.CreateLeveragesSource(wordOfPreacherMain, null, "Word of Preacher", "Слово проповедника", "Слово проповедника накладывает негативный эффект", "словом проповедника");
            IUnitLeveragesSource preacherArmouredBody = leveragesSourcesService.CreateUnitLeverageSource(wordOfPreacher, LeveragesPriority.PrimalPriority, new LeverageEffectsApplying(10, LeverageType.NegativeEffectApplying));
            crls.Add(preacherArmouredBody);

            return crls;
        }

        private static List<IUnitLeveragesSource> CreateRagerLeveragesSources()
        {
            List<IUnitLeveragesSource> crls = new();
            ILeveragesSourcesService leveragesSourcesService = new LeverageSourcesService();

            ILeverageService leverageService = new LeverageService();
            List<ILeverageClass> leverageClasses = CreateLeverageClasses(leverageService);
            List<ILeverageOption> leverageOptions = CreateLeverageOptions(leverageService);

            // тело в доспехах
            ILeverage armouredBodyMain = leverageService.CreateLeverage(
                leverageClasses[0],
                LeverageTargetType.Enemies,
                LeverageHitPoint.Route,
                LeverageRangeType.Melee,
                LeverageTargeting.Place,
                new List<ILeverageOption>() { leverageOptions[1] });
            ILeveragesSource armouredBody = leveragesSourcesService.CreateLeveragesSource(armouredBodyMain, null, "Armoured body", "Тело в доспехах", "Тело в доспехах давит другую цель", "телом в доспехах");
            IUnitLeveragesSource ragerArmouredBody = leveragesSourcesService.CreateUnitLeverageSource(armouredBody, LeveragesPriority.SupportPriority, new LeverageHit(10, 20, 5, LeverageType.Damage));
            crls.Add(ragerArmouredBody);

            // удар с поджогом
            ILeverage blowWithFireMain = leverageService.CreateLeverage(
                leverageClasses[1], 
                LeverageTargetType.Enemies, 
                LeverageHitPoint.Vision, 
                LeverageRangeType.Melee, 
                LeverageTargeting.Single, 
                new List<ILeverageOption> { leverageOptions[1] });

            ILeverage blowWithFireAdditional = leverageService.CreateLeverage(
                leverageClasses[2], 
                LeverageTargetType.Enemies, 
                LeverageHitPoint.Vision, 
                LeverageRangeType.Melee,
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[1] });

            ILeveragesSource blowWithFire = leveragesSourcesService.CreateLeveragesSource(
                blowWithFireMain, blowWithFireAdditional, "Blow with fire", "Удар с поджогом", "Физический удар юнита c поджогом по цели", "ударом c поджогом");

            IUnitLeveragesSource ragerBlowWithFire = leveragesSourcesService.CreateUnitLeverageSource(
                blowWithFire, 
                LeveragesPriority.LowPriority, 
                new LeverageHit(5, 8, 3, LeverageType.Damage), 
                new TargetPeriodicDamageEffect(2, blowWithFire.AdditionalLeverage.Class, 6, "Воспламенение", 2, 5));

            crls.Add(ragerBlowWithFire);

            // пылающий двуручный топор
            ILeverage flamingAxeMain = leverageService.CreateLeverage(
                leverageClasses[1], 
                LeverageTargetType.Enemies, 
                LeverageHitPoint.FrontHemisphere, 
                LeverageRangeType.Melee, 
                LeverageTargeting.Many, 
                new List<ILeverageOption> { leverageOptions[1], leverageOptions[3] });
            ILeverage flamingAxeAdditional = leverageService.CreateLeverage(
                leverageClasses[2], 
                LeverageTargetType.Enemies, 
                LeverageHitPoint.FrontHemisphere, 
                LeverageRangeType.Melee, 
                LeverageTargeting.Many,
                new List<ILeverageOption> { leverageOptions[0], leverageOptions[4] });
            ILeveragesSource flamingAxe = leveragesSourcesService.CreateLeveragesSource(
                flamingAxeMain, flamingAxeAdditional, "Flaming axe", "Пылающий двуручный топор", "Убийственный рассекающий огромный огненный топор", "пылающим двуручным топором");
            IUnitLeveragesSource ragerFlamingAxe = leveragesSourcesService.CreateUnitLeverageSource(
                flamingAxe, 
                LeveragesPriority.PrimalPriority, 
                new LeverageHit(50, 55, 8, LeverageType.Damage), 
                new TargetPeriodicDamageEffect(8, flamingAxe.AdditionalLeverage.Class, 14, "Воспламенение", 10, 12));
            crls.Add(ragerFlamingAxe);

            // пылающий меч
            ILeverage flamingSwordMain = leverageService.CreateLeverage(
                leverageClasses[1],
                LeverageTargetType.Enemies,
                LeverageHitPoint.Vision,
                LeverageRangeType.Melee,
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[1], leverageOptions[3] });

            ILeverage flamingSwordAdditional = leverageService.CreateLeverage(
                leverageClasses[2], 
                LeverageTargetType.Enemies, 
                LeverageHitPoint.Vision, 
                LeverageRangeType.Melee, 
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[0], leverageOptions[4] });

            ILeveragesSource flamingSword = leveragesSourcesService.CreateLeveragesSource(
                flamingSwordMain, flamingSwordAdditional, "Flaming sword", "Пылающий меч", "Огромный огненный рассекающий меч", "пылающим мечом");

            IUnitLeveragesSource ragerFlamingSword = leveragesSourcesService.CreateUnitLeverageSource(
                flamingSword, 
                LeveragesPriority.AdvancedPriority, 
                new LeverageHit(35, 38, 3, LeverageType.Damage), 
                new TargetPeriodicDamageEffect(3, flamingSword.AdditionalLeverage.Class, 6, "Воспламенение", 5, 8));

            crls.Add(ragerFlamingSword);

            // удар древком
            ILeverage blowWithShaftMain = leverageService.CreateLeverage(
                leverageClasses[1], 
                LeverageTargetType.Enemies, 
                LeverageHitPoint.Vision, 
                LeverageRangeType.Melee, 
                LeverageTargeting.Single,
                new List<ILeverageOption> { leverageOptions[1] });
            ILeveragesSource blowWithShaft = leveragesSourcesService.CreateLeveragesSource(
               blowWithShaftMain, null, "Blow with shaft", "Удар древком", "Удар древком двуручного топора", "ударом древка топора");
            IUnitLeveragesSource ragerBlowWithShaft = leveragesSourcesService.CreateUnitLeverageSource(blowWithShaft, LeveragesPriority.BasePriority, new LeverageHit(13, 18, 4, LeverageType.Damage));
            crls.Add(ragerBlowWithShaft);

            // взрывной рык
            ILeverage explosiveRoarMain = leverageService.CreateLeverage(
                leverageClasses[3], 
                LeverageTargetType.Enemies, 
                LeverageHitPoint.SpaceAroundUnit, 
                LeverageRangeType.Melee, 
                LeverageTargeting.Many,
                new List<ILeverageOption> { leverageOptions[5]});
            ILeveragesSource explosiveRoar = leveragesSourcesService.CreateLeveragesSource(
                explosiveRoarMain, null, "Explosive roar", "Взрывной рык", "Ужасающий рык, взрывающий всё вокруг", "взрывным рыком");
            IUnitLeveragesSource ragerExprosiveRoar = leveragesSourcesService.CreateUnitLeverageSource(explosiveRoar, LeveragesPriority.HighPriority, new LeverageHit(30, 67, 10, LeverageType.Damage));
            crls.Add(ragerExprosiveRoar);

            return crls;
        }

        private static List<ILeverageClass> CreateLeverageClasses(ILeverageService leverageService)
        {
            List<ILeverageClass> leverageTypes = new()
            {
                leverageService.CreateLeverageClass("Давление", "Pressure", "#999999", "урона давлением", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Физика", "Physics", "#ca87e3", "физического урона", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Огонь", "Fire", "#ea9999", "огненного урона", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Взрыв", "Explosion", "#f6b26b", "взрывного урона", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Лечение", "Healing", "#a4c2f4", "исцеления", LeverageType.Recovery, LeverageClassRestrictions.OrganicAndAlive),
                leverageService.CreateLeverageClass("Нетрализация", "Neutralization", "#efefef", "нейтрализации", LeverageType.NegativeEffectRemoval, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Благо","Bless", "#efefef", "единиц здоровья", LeverageType.PositiveEffectApplying, LeverageClassRestrictions.OrganicAndAlive),
                leverageService.CreateLeverageClass("Защита", "Defence", "565656", "уменьшения урона", LeverageType.PositiveEffectApplying, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Пролом", "Break", "232323", "пролома", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Усиление", "Gain", "ffddaa", "усиления", LeverageType.PositiveEffectApplying, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Слабость", "Weakness", "334221", "слабости", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Воля", "Will", "#ffc0cb", "воли", LeverageType.NegativeEffectApplying, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Иссушение", "DryingOut", "#ffdbac", "иссушения", LeverageType.Damage, LeverageClassRestrictions.OrganicAndAlive),
                leverageService.CreateLeverageClass("Размещение", "Accommodation", "#800080", "размещения", LeverageType.Creation, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Разрушение", "Destruction", "#fffdd0", "разрушения", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Энергия", "Energy", "#0000ff", "энергии", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions),
                leverageService.CreateLeverageClass("Расщепление", "Split", "#ff0000", "расщепления", LeverageType.Damage, LeverageClassRestrictions.NoRestrictions)
            };
            return leverageTypes;
        }

        private static List<ILeverageOption> CreateLeverageOptions(ILeverageService leverageService)
        {
            List<ILeverageOption> leverageClasses = new()
            {
                leverageService.CreateLeverageOption("Стихийное", "Elemental", "Воздействие одной из стихий"),
                leverageService.CreateLeverageOption("Ближний бой", "Melee", "Воздейтвие происходит только при непосредственном контакте с целью"),
                leverageService.CreateLeverageOption("Дальний бой", "Ranged", "Воздейтвие происходит даже при наличии расстояния между источником и целью"),
                leverageService.CreateLeverageOption("Рубящее оружие", "Slashing weapon", "Оружие разрубает цель или способно отрезать какие-то части"),
                leverageService.CreateLeverageOption("При попадании", "When hit", "Дополнительное воздейтвие происходит только при попадании основным"),
                leverageService.CreateLeverageOption("Слово", "Word", "Произнессённое юнитом слово"),
                leverageService.CreateLeverageOption("Заклинание", "Spell", "Использованное заклинание"),
                leverageService.CreateLeverageOption("Выбор зоны применения", "Choosing area", "Требуется выбрать зону применения умения")
            };
            return leverageClasses;
        }
    }
}
