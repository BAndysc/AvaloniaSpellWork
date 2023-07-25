using System;
using SpellWork.DBC;
using SpellWork.Spell;
using SpellWork.ViewModels;

namespace SpellWork
{
    public class Loader
    {
        public Loader()
        {
            
        }

        public async Task AsyncDataLoad(ITaskProgress progress)
        {
            progress.Report(nameof(DBC.DBC.AreaGroup));
            DBC.DBC.AreaGroup = await DBCReader.ReadDBC<AreaGroupEntry>(null);
            
            progress.Report(nameof(DBC.DBC.AreaTable));
            DBC.DBC.AreaTable = await DBCReader.ReadDBC<AreaTableEntry>(DBC.DBC.AreaStrings);
            
            progress.Report(nameof(DBC.DBC.OverrideSpellData));
            DBC.DBC.OverrideSpellData = await DBCReader.ReadDBC<OverrideSpellDataEntry>(null);
            
            progress.Report(nameof(DBC.DBC.ScreenEffect));
            DBC.DBC.ScreenEffect = await DBCReader.ReadDBC<ScreenEffectEntry>(DBC.DBC.ScreenEffectStrings);
            
            progress.Report(nameof(DBC.DBC.SkillLine));
            DBC.DBC.SkillLine = await DBCReader.ReadDBC<SkillLineEntry>(DBC.DBC.SkillLineStrings);
            
            progress.Report(nameof(DBC.DBC.SkillLineAbility));
            DBC.DBC.SkillLineAbility = await DBCReader.ReadDBC<SkillLineAbilityEntry>(null);
            
            progress.Report(nameof(DBC.DBC.Spell));
            DBC.DBC.Spell = await DBCReader.ReadDBC<SpellEntry>(DBC.DBC.SpellStrings);
            
            progress.Report(nameof(DBC.DBC.SpellCastTimes));
            DBC.DBC.SpellCastTimes = await DBCReader.ReadDBC<SpellCastTimesEntry>(null);
            
            progress.Report(nameof(DBC.DBC.SpellDifficulty));
            DBC.DBC.SpellDifficulty = await DBCReader.ReadDBC<SpellDifficultyEntry>(null);
            
            progress.Report(nameof(DBC.DBC.SpellDuration));
            DBC.DBC.SpellDuration = await DBCReader.ReadDBC<SpellDurationEntry>(null);
            
            progress.Report(nameof(DBC.DBC.SpellRadius));
            DBC.DBC.SpellRadius = await DBCReader.ReadDBC<SpellRadiusEntry>(null);
            
            progress.Report(nameof(DBC.DBC.SpellRange));
            DBC.DBC.SpellRange = await DBCReader.ReadDBC<SpellRangeEntry>(DBC.DBC.SpellRangeStrings);
            
            progress.Report(nameof(DBC.DBC.SpellMissile));
            DBC.DBC.SpellMissile = await DBCReader.ReadDBC<SpellMissileEntry>(null);
            
            progress.Report(nameof(DBC.DBC.SpellMissileMotion));
            DBC.DBC.SpellMissileMotion = await DBCReader.ReadDBC<SpellMissileMotionEntry>(DBC.DBC.SpellMissileMotionStrings);
            
            progress.Report(nameof(DBC.DBC.SpellVisual));
            DBC.DBC.SpellVisual = await DBCReader.ReadDBC<SpellVisualEntry>(null);

            DBC.DBC.Locale = DetectedLocale;
        }

        /// <exception cref="Exception"><c>Exception</c>.</exception>
        private static LocalesDBC DetectedLocale
        {
            get
            {
                byte locale = 0;
                while (DBC.DBC.Spell[DBC.DBC.SpellEntryForDetectLocale].GetName(locale) == String.Empty)
                {
                    ++locale;

                    if (locale >= DBC.DBC.MaxDbcLocale)
                        throw new Exception("Detected unknown locale index " + locale);
                }
                return (LocalesDBC)locale;
            }
        }
    }
}
