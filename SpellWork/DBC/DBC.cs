using DBFileReaderLib;
using SpellWork.DBC.Structures;
using SpellWork.Extensions;
using SpellWork.GameTables;
using SpellWork.GameTables.Structures;
using SpellWork.Properties;
using SpellWork.Spell;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SpellWork.Database;
using SpellWork.ViewModels;

namespace SpellWork.DBC
{
    public static class DBC
    {
        public const string Version = "SpellWork 10.1.0 (49318)";
        public const uint MaxLevel = 70;
        public const uint MaxItemLevel = 1300;

        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable CollectionNeverUpdated.Global
        public static Storage<AreaGroupMemberEntry>             AreaGroupMember { get; set; }
        public static Storage<AreaTableEntry>                   AreaTable { get; set; }
        public static Storage<ContentTuningEntry>               ContentTuning { get; set; }
        public static Storage<ContentTuningXExpectedEntry>      ContentTuningXExpected { get; set; }
        public static Storage<DifficultyEntry>                  Difficulty { get; set; }
        public static Storage<ExpectedStatEntry>                ExpectedStat { get; set; }
        public static Storage<ExpectedStatModEntry>             ExpectedStatMod { get; set; }
        public static Storage<MapEntry>                         Map { get; set; }
        public static Storage<MapDifficultyEntry>               MapDifficulty { get; set; }
        public static Storage<OverrideSpellDataEntry>           OverrideSpellData { get; set; }
        public static Storage<ScreenEffectEntry>                ScreenEffect { get; set; }
        public static Storage<SpellEntry>                       Spell { get; set; }
        public static Storage<SpellNameEntry>                   SpellName { get; set; }
        public static Storage<SpellAuraOptionsEntry>            SpellAuraOptions { get; set; }
        public static Storage<SpellAuraRestrictionsEntry>       SpellAuraRestrictions { get; set; }
        public static Storage<SpellCastingRequirementsEntry>    SpellCastingRequirements { get; set; }
        public static Storage<SpellCastTimesEntry>              SpellCastTimes { get; set; }
        public static Storage<SpellCategoriesEntry>             SpellCategories { get; set; }
        public static Storage<SpellCategoryEntry>               SpellCategory { get; set; }
        public static Storage<SpellClassOptionsEntry>           SpellClassOptions { get; set; }
        public static Storage<SpellCooldownsEntry>              SpellCooldowns { get; set; }
        public static Storage<SpellDescriptionVariablesEntry>   SpellDescriptionVariables { get; set; }
        public static Storage<SpellDurationEntry>               SpellDuration { get; set; }
        public static Storage<SpellEffectEntry>                 SpellEffect { get; set; }
        public static Storage<SpellMiscEntry>                   SpellMisc { get; set; }
        public static Storage<SpellEquippedItemsEntry>          SpellEquippedItems { get; set; }
        public static Storage<SpellInterruptsEntry>             SpellInterrupts { get; set; }
        public static Storage<SpellLabelEntry>                  SpellLabel { get; set; }
        public static Storage<SpellLevelsEntry>                 SpellLevels { get; set; }
        public static Storage<SpellPowerEntry>                  SpellPower { get; set; }
        public static Storage<SpellRadiusEntry>                 SpellRadius { get; set; }
        public static Storage<SpellRangeEntry>                  SpellRange { get; set; }
        public static Storage<SpellScalingEntry>                SpellScaling { get; set; }
        public static Storage<SpellShapeshiftEntry>             SpellShapeshift { get; set; }
        public static Storage<SpellTargetRestrictionsEntry>     SpellTargetRestrictions { get; set; }
        public static Storage<SpellTotemsEntry>                 SpellTotems { get; set; }
        public static Storage<SpellXDescriptionVariablesEntry>  SpellXDescriptionVariables { get; set; }
        public static Storage<SpellXSpellVisualEntry>           SpellXSpellVisual { get; set; }
        public static Storage<RandPropPointsEntry>              RandPropPoints { get; set; }
        public static Storage<SpellProcsPerMinuteEntry>         SpellProcsPerMinute { get; set; }

        public static Storage<SkillLineAbilityEntry>            SkillLineAbility { get; set; }
        public static Storage<SkillLineEntry>                   SkillLine { get; set; }

        public static Storage<ItemEntry>                        Item { get; set; }
        public static Storage<ItemEffectEntry>                  ItemEffect { get; set; }
        public static Storage<ItemSparseEntry>                  ItemSparse { get; set; }
        public static Storage<ItemXItemEffectEntry>             ItemXItemEffect { get; set; }

        public static Storage<SpellReagentsEntry>               SpellReagents { get; set; }
        public static Storage<SpellReagentsCurrencyEntry>       SpellReagentsCurrency { get; set; }
        public static Storage<SpellMissileEntry>                SpellMissile { get; set; }
        // ReSharper restore MemberCanBePrivate.Global
        // ReSharper restore CollectionNeverUpdated.Global

        // public static Storage<SpellMissileMotionEntry>         SpellMissileMotion { get; public set; }
        // public static Storage<SpellVisualEntry>                SpellVisual { get; public set; }

        public static readonly IDictionary<int, SpellInfo> SpellInfoStore = new ConcurrentDictionary<int, SpellInfo>();
        public static readonly IDictionary<int, ISet<int>> SpellTriggerStore = new Dictionary<int, ISet<int>>();

        public static async Task Load(ITaskProgress progress)
        {
            HotfixReader hotfixReader = null;
            try
            {
                //hotfixReader = new HotfixReader(Settings.Default.HotfixCachePath);
            }
            catch (Exception)
            {
                Console.WriteLine(
                    $"Hotfix cache {Settings.Default.HotfixCachePath} cannot be loaded, ignoring!");
            }

            
            var dbcs = typeof(DBC).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(dbc => dbc.PropertyType.IsGenericType && dbc.PropertyType.GetGenericTypeDefinition() == typeof(Storage<>))
                    .ToList();
            
            Console.WriteLine("Has  "  + dbcs.Count);

            Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();
            foreach (var dbc in dbcs)
            {
                var name = dbc.Name;
                //var db2Reader = new DBReader($@"{Settings.Default.DbcPath}\{Settings.Default.Locale}\{name}.db2");
                var task = Globals.FileSystem.ReadFile($"{name}.db2");
                var bytes = await task;
                files.Add(name, bytes);
            }

            Dictionary<string, ISubTaskProgress> tasks = new Dictionary<string, ISubTaskProgress>();
            foreach (var dbc in dbcs)
            {
                var name = dbc.Name;
                tasks.Add(name, progress.CreateSubTask(name + ".db2"));
            }
            
            var spellMisc = progress.CreateSubTask("SpellMisc.db2 post processing");
            var spellEffect = progress.CreateSubTask("SpellEffect.db2 post processing");
            var spellTargetRestriction = progress.CreateSubTask("SpellTargetRestrictions.db2 post processing");
            var spellXSpellVisual = progress.CreateSubTask("SpellXSpellVisual.db2 post processing");
            var spellScaling = progress.CreateSubTask("SpellScaling.db2 post processing");
            var spellAuraOptions = progress.CreateSubTask("SpellAuraOptions.db2 post processing");
            var spellAuraRestrictions = progress.CreateSubTask("SpellAuraRestrictions.db2 post processing");
            var spellCategories = progress.CreateSubTask("SpellCategories.db2 post processing");
            var spellCastingRequirements = progress.CreateSubTask("SpellCastingRequirements.db2 post processing");
            var spellClassOptions = progress.CreateSubTask("SpellClassOptions.db2 post processing");
            var spellCooldowns = progress.CreateSubTask("SpellCooldowns.db2 post processing");
            var spellInterrupts = progress.CreateSubTask("SpellInterrupts.db2 post processing");
            var spellEquippedItems = progress.CreateSubTask("SpellEquippedItems.db2 post processing");
            var spellLabel = progress.CreateSubTask("SpellLabel.db2 post processing");
            var spellLevels = progress.CreateSubTask("SpellLevels.db2 post processing");
            var spellPower = progress.CreateSubTask("SpellPower.db2 post processing");
            var spellShapeshift = progress.CreateSubTask("SpellShapeshift.db2 post processing");
            var spellTotems = progress.CreateSubTask("SpellTotems.db2 post processing");
            var spellXDescriptionVariables = progress.CreateSubTask("SpellXDescriptionVariables.db2 post processing");
            var spellReagents = progress.CreateSubTask("SpellReagents.db2 post processing");
            var spellReagentsCurrency = progress.CreateSubTask("SpellReagentsCurrency.db2 post processing");
            
            async Task DoLoad<T>(string name, Action<Storage<T>> onLoaded) where T : class, new()
            {
                var progress = tasks[name];
                progress.Report("loading");
                await Task.Run(() =>
                {
                    try
                    {
                        var stream = new MemoryStream(files[name]);
                        var db2Reader = new DBReader(stream);

                        var storage = new Storage<T>(db2Reader);

                        if (hotfixReader != null)
                            hotfixReader.ApplyHotfixes(storage, db2Reader);

                        onLoaded(storage);
                    }
                    catch (DirectoryNotFoundException)
                    {
                    }
                    catch (TargetInvocationException tie)
                    {
                        if (tie.InnerException is ArgumentException)
                            throw new ArgumentException($"Failed to load {name}.db2: {tie.InnerException.Message}");
                        throw;
                    }
                });
                progress.Report("done");
            }
            
            List<Func<Task>> loadTasks = new List<Func<Task>>() {
                () => DoLoad<AreaGroupMemberEntry>(nameof(AreaGroupMember), storage => AreaGroupMember = storage),
                () => DoLoad<AreaTableEntry>(nameof(AreaTable), storage => AreaTable = storage),
                () => DoLoad<ContentTuningEntry>(nameof(ContentTuning), storage => ContentTuning = storage),
                () => DoLoad<ContentTuningXExpectedEntry>(nameof(ContentTuningXExpected), storage => ContentTuningXExpected = storage),
                () => DoLoad<DifficultyEntry>(nameof(Difficulty), storage => Difficulty = storage),
                () => DoLoad<ExpectedStatEntry>(nameof(ExpectedStat), storage => ExpectedStat = storage),
                () => DoLoad<ExpectedStatModEntry>(nameof(ExpectedStatMod), storage => ExpectedStatMod = storage),
                () => DoLoad<MapEntry>(nameof(Map), storage => Map = storage),
                () => DoLoad<MapDifficultyEntry>(nameof(MapDifficulty), storage => MapDifficulty = storage),
                () => DoLoad<OverrideSpellDataEntry>(nameof(OverrideSpellData), storage => OverrideSpellData = storage),
                () => DoLoad<ScreenEffectEntry>(nameof(ScreenEffect), storage => ScreenEffect = storage),
                () => DoLoad<SpellEntry>(nameof(Spell), storage => Spell = storage),
                () => DoLoad<SpellNameEntry>(nameof(SpellName), storage => SpellName = storage),
                () => DoLoad<SpellAuraOptionsEntry>(nameof(SpellAuraOptions), storage => SpellAuraOptions = storage),
                () => DoLoad<SpellAuraRestrictionsEntry>(nameof(SpellAuraRestrictions), storage => SpellAuraRestrictions = storage),
                () => DoLoad<SpellCastingRequirementsEntry>(nameof(SpellCastingRequirements), storage => SpellCastingRequirements = storage),
                () => DoLoad<SpellCastTimesEntry>(nameof(SpellCastTimes), storage => SpellCastTimes = storage),
                () => DoLoad<SpellCategoriesEntry>(nameof(SpellCategories), storage => SpellCategories = storage),
                () => DoLoad<SpellCategoryEntry>(nameof(SpellCategory), storage => SpellCategory = storage),
                () => DoLoad<SpellClassOptionsEntry>(nameof(SpellClassOptions), storage => SpellClassOptions = storage),
                () => DoLoad<SpellCooldownsEntry>(nameof(SpellCooldowns), storage => SpellCooldowns = storage),
                () => DoLoad<SpellDescriptionVariablesEntry>(nameof(SpellDescriptionVariables), storage => SpellDescriptionVariables = storage),
                () => DoLoad<SpellDurationEntry>(nameof(SpellDuration), storage => SpellDuration = storage),
                () => DoLoad<SpellEffectEntry>(nameof(SpellEffect), storage => SpellEffect = storage),
                () => DoLoad<SpellMiscEntry>(nameof(SpellMisc), storage => SpellMisc = storage),
                () => DoLoad<SpellEquippedItemsEntry>(nameof(SpellEquippedItems), storage => SpellEquippedItems = storage),
                () => DoLoad<SpellInterruptsEntry>(nameof(SpellInterrupts), storage => SpellInterrupts = storage),
                () => DoLoad<SpellLabelEntry>(nameof(SpellLabel), storage => SpellLabel = storage),
                () => DoLoad<SpellLevelsEntry>(nameof(SpellLevels), storage => SpellLevels = storage),
                () => DoLoad<SpellPowerEntry>(nameof(SpellPower), storage => SpellPower = storage),
                () => DoLoad<SpellRadiusEntry>(nameof(SpellRadius), storage => SpellRadius = storage),
                () => DoLoad<SpellRangeEntry>(nameof(SpellRange), storage => SpellRange = storage),
                () => DoLoad<SpellScalingEntry>(nameof(SpellScaling), storage => SpellScaling = storage),
                () => DoLoad<SpellShapeshiftEntry>(nameof(SpellShapeshift), storage => SpellShapeshift = storage),
                () => DoLoad<SpellTargetRestrictionsEntry>(nameof(SpellTargetRestrictions), storage => SpellTargetRestrictions = storage),
                () => DoLoad<SpellTotemsEntry>(nameof(SpellTotems), storage => SpellTotems = storage),
                () => DoLoad<SpellXDescriptionVariablesEntry>(nameof(SpellXDescriptionVariables), storage => SpellXDescriptionVariables = storage),
                () => DoLoad<SpellXSpellVisualEntry>(nameof(SpellXSpellVisual), storage => SpellXSpellVisual = storage),
                () => DoLoad<RandPropPointsEntry>(nameof(RandPropPoints), storage => RandPropPoints = storage),
                () => DoLoad<SpellProcsPerMinuteEntry>(nameof(SpellProcsPerMinute), storage => SpellProcsPerMinute = storage),
                () => DoLoad<SkillLineAbilityEntry>(nameof(SkillLineAbility), storage => SkillLineAbility = storage),
                () => DoLoad<SkillLineEntry>(nameof(SkillLine), storage => SkillLine = storage),
                () => DoLoad<ItemEntry>(nameof(Item), storage => Item = storage),
                () => DoLoad<ItemEffectEntry>(nameof(ItemEffect), storage => ItemEffect = storage),
                () => DoLoad<ItemSparseEntry>(nameof(ItemSparse), storage => ItemSparse = storage),
                () => DoLoad<ItemXItemEffectEntry>(nameof(ItemXItemEffect), storage => ItemXItemEffect = storage),
                () => DoLoad<SpellReagentsEntry>(nameof(SpellReagents), storage => SpellReagents = storage),
                () => DoLoad<SpellReagentsCurrencyEntry>(nameof(SpellReagentsCurrency), storage => SpellReagentsCurrency = storage),
                () => DoLoad<SpellMissileEntry>(nameof(SpellMissile), storage => SpellMissile = storage)
            };

            // multithreading and browser support doesn't work well together
            if (OperatingSystem.IsBrowser())
            {
                foreach (var t in loadTasks)
                    await t();
            }
            else
                await Task.WhenAll(loadTasks.Select(t => t()));
            
            foreach (var spell in SpellName)
                SpellInfoStore[(int)spell.Value.ID] = new SpellInfo(spell.Value, Spell.GetValue((int)spell.Value.ID));

            async Task RunProgressTask(ISubTaskProgress progress, Action action)
            {
                progress.Report("loading");
                await Task.Run(action);
                progress.Report("done");
            }
            
            await Task.WhenAll(RunProgressTask(spellMisc, () =>
            {
                foreach (var spellMisc in SpellMisc.Values.Where(misc => SpellInfoStore.ContainsKey(misc.SpellID)))
                {
                    if (spellMisc.DifficultyID != 0)
                        continue;

                    var spell = SpellInfoStore[spellMisc.SpellID];

                    spell.Misc = spellMisc;

                    if (SpellDuration.TryGetValue(spellMisc.DurationIndex, out var value))
                        spell.DurationEntry = value;

                    if (SpellRange.TryGetValue(spellMisc.RangeIndex, out var value2))
                        spell.Range = value2;
                }
            }), RunProgressTask(spellEffect, () =>
            {
                foreach (var effect in SpellEffect.Values)
                {
                    if (!SpellInfoStore.ContainsKey(effect.SpellID))
                    {
                        Console.WriteLine(
                            $"Spell effect {effect.ID} is referencing unknown spell {effect.SpellID}, ignoring!");
                        continue;
                    }

                    SpellInfoStore[effect.SpellID].Effects.Add(effect);
                    SpellInfoStore[effect.SpellID].SpellEffectInfoStore[effect.EffectIndex] = new SpellEffectInfo(effect); // Helper

                    var triggerId = effect.EffectTriggerSpell;
                    if (triggerId != 0)
                    {
                        if (SpellTriggerStore.TryGetValue(triggerId, out var value))
                            value.Add(effect.SpellID);
                        else
                            SpellTriggerStore.Add(triggerId, new SortedSet<int> { effect.SpellID });
                    }
                }
            }), RunProgressTask(spellTargetRestriction, () =>
            {
                foreach (var spellTargetRestrictions in SpellTargetRestrictions.Values)
                {
                    if (spellTargetRestrictions.DifficultyID != 0)
                        continue;

                    if (!SpellInfoStore.ContainsKey(spellTargetRestrictions.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellTargetRestrictions: Unknown spell {spellTargetRestrictions.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellTargetRestrictions.SpellID].TargetRestrictions = spellTargetRestrictions;
                }
            }), RunProgressTask(spellXSpellVisual, () =>
            {
                foreach (var spellXSpellVisual in SpellXSpellVisual.Values.Where(effect => effect.CasterPlayerConditionID == 0))
                {
                    if (spellXSpellVisual.DifficultyID != 0)
                        continue;

                    if (!SpellInfoStore.ContainsKey(spellXSpellVisual.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellXSpellVisual: Unknown spell {spellXSpellVisual.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellXSpellVisual.SpellID].SpellXSpellVisual = spellXSpellVisual;
                }
            }), RunProgressTask(spellScaling, () =>
            {
                foreach (var spellScaling in SpellScaling.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellScaling.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellScaling: Unknown spell {spellScaling.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellScaling.SpellID].Scaling = spellScaling;
                }
            }), RunProgressTask(spellAuraOptions, () =>
            {
                foreach (var spellAuraOptions in SpellAuraOptions.Values)
                {
                    if (spellAuraOptions.DifficultyID != 0)
                        continue;

                    if (!SpellInfoStore.ContainsKey(spellAuraOptions.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellAuraOptions: Unknown spell {spellAuraOptions.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellAuraOptions.SpellID].AuraOptions = spellAuraOptions;
                    if (spellAuraOptions.SpellProcsPerMinuteID != 0)
                        SpellInfoStore[spellAuraOptions.SpellID].ProcsPerMinute = SpellProcsPerMinute[spellAuraOptions.SpellProcsPerMinuteID];
                }
            }), RunProgressTask(spellAuraRestrictions, () =>
            {
                foreach (var spellAuraRestrictions in SpellAuraRestrictions.Values)
                {
                    if (spellAuraRestrictions.DifficultyID != 0)
                        continue;

                    if (!SpellInfoStore.ContainsKey(spellAuraRestrictions.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellAuraRestrictions: Unknown spell {spellAuraRestrictions.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellAuraRestrictions.SpellID].AuraRestrictions = spellAuraRestrictions;
                }
            }), RunProgressTask(spellCategories, () =>
            {
                foreach (var spellCategories in SpellCategories.Values)
                {
                    if (spellCategories.DifficultyID != 0)
                        continue;

                    if (!SpellInfoStore.ContainsKey(spellCategories.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellCategories: Unknown spell {spellCategories.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellCategories.SpellID].Categories = spellCategories;
                }
            }), RunProgressTask(spellCastingRequirements, () =>
            {
                foreach (var spellCastingRequirements in SpellCastingRequirements.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellCastingRequirements.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellCastingRequirements: Unknown spell {spellCastingRequirements.SpellID} referenced, ignoring!");
                        return;
                    }

                    SpellInfoStore[spellCastingRequirements.SpellID].CastingRequirements = spellCastingRequirements;
                }
            }), RunProgressTask(spellClassOptions, () =>
            {
                foreach (var spellClassOptions in SpellClassOptions.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellClassOptions.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellClassOptions: Unknown spell {spellClassOptions.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellClassOptions.SpellID].ClassOptions = spellClassOptions;
                }
            }), RunProgressTask(spellCooldowns, () =>
            {
                foreach (var spellCooldowns in SpellCooldowns.Values)
                {
                    if (spellCooldowns.DifficultyID != 0)
                        continue;

                    if (!SpellInfoStore.ContainsKey(spellCooldowns.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellCooldowns: Unknown spell {spellCooldowns.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellCooldowns.SpellID].Cooldowns = spellCooldowns;
                }
            }), RunProgressTask(spellInterrupts, () =>
            {
                foreach (var effect in SpellInterrupts)
                {
                    if (effect.Value.DifficultyID != 0)
                        continue;

                    if (!SpellInfoStore.ContainsKey(effect.Value.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellInterrupts: Unknown spell {effect.Value.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[effect.Value.SpellID].Interrupts = effect.Value;
                }
            }), RunProgressTask(spellEquippedItems, () =>
            {
                foreach (var spellEquippedItems in SpellEquippedItems.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellEquippedItems.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellEquippedItems: Unknown spell {spellEquippedItems.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellEquippedItems.SpellID].EquippedItems = spellEquippedItems;
                }
            }), RunProgressTask(spellLabel, () =>
            {
                foreach (var spellLabel in SpellLabel.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellLabel.SpellID))
                    {
                        Console.WriteLine($"SpellLabel: Unknown spell {spellLabel.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellLabel.SpellID].Labels.Add(spellLabel.LabelID);
                }
            }), RunProgressTask(spellLevels, () =>
            {
                foreach (var spellLevels in SpellLevels.Values)
                {
                    if (spellLevels.DifficultyID != 0)
                        continue;

                    if (!SpellInfoStore.ContainsKey(spellLevels.SpellID))
                    {
                        Console.WriteLine($"SpellLevels: Unknown spell {spellLevels.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellLevels.SpellID].Levels = spellLevels;
                }
            }), RunProgressTask(spellPower, () =>
            {
                foreach (var spellPower in SpellPower.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellPower.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellPower: Unknown spell {spellPower.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellPower.SpellID].Powers.Add(spellPower);
                }
            }), RunProgressTask(spellReagents, () =>
            {
                foreach (var spellReagents in SpellReagents.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellReagents.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellReagents: Unknown spell {spellReagents.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellReagents.SpellID].Reagents = spellReagents;
                }
            }), RunProgressTask(spellReagentsCurrency, () =>
            {
                foreach (var spellReagentsCurrency in SpellReagentsCurrency.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellReagentsCurrency.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellReagentsCurrency: Unknown spell {spellReagentsCurrency.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellReagentsCurrency.SpellID].ReagentsCurrency.Add(spellReagentsCurrency);
                }
            }), RunProgressTask(spellShapeshift, () =>
            {
                foreach (var spellShapeshift in SpellShapeshift.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellShapeshift.SpellID))
                    {
                        Console.WriteLine(
                            $"SpellShapeshift: Unknown spell {spellShapeshift.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellShapeshift.SpellID].Shapeshift = spellShapeshift;
                }
            }), RunProgressTask(spellTotems, () =>
            {
                foreach (var spellTotems in SpellTotems.Values)
                {
                    if (!SpellInfoStore.ContainsKey(spellTotems.SpellID))
                    {
                        Console.WriteLine($"SpellTotems: Unknown spell {spellTotems.SpellID} referenced, ignoring!");
                        continue;
                    }

                    SpellInfoStore[spellTotems.SpellID].Totems = spellTotems;
                }
            }), RunProgressTask(spellXDescriptionVariables, () =>
            {
                foreach (var descriptionVariable in SpellXDescriptionVariables.Values)
                {
                    if (!SpellInfoStore.ContainsKey(descriptionVariable.SpellID))
                    {
                        Console.WriteLine($"SpellXDescriptionVariables: Unknown spell {descriptionVariable.SpellID} referenced, ignoring!");
                        continue;
                    }
                    SpellInfoStore[descriptionVariable.SpellID].DescriptionVariables = SpellDescriptionVariables.GetValue(descriptionVariable.SpellDescriptionVariablesID);
                }
            }));

            //MySqlConnection.LoadServersideSpells();

            //GameTable<GtSpellScalingEntry>.Open($@"{Settings.Default.GtPath}\SpellScaling.txt");
        }

        public static uint SelectedLevel = MaxLevel;
        public static uint SelectedItemLevel = 475;
        public static MapDifficultyEntry SelectedMapDifficulty;
    }
}
