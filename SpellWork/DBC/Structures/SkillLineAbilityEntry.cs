﻿using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SkillLineAbilityEntry
    {
        public long RaceMask;
        public string AbilityVerb;
        public string AbilityAllVerb;
        [Index(false)]
        public uint ID;
        public short SkillLine;
        public int Spell;
        public short MinSkillLineRank;
        public int ClassMask;
        public int SupercedesSpell;
        public sbyte AcquireMethod;
        public short TrivialSkillLineRankHigh;
        public short TrivialSkillLineRankLow;
        public int Flags;
        public sbyte NumSkillUps;
        public short UniqueBit;
        public short TradeSkillCategoryID;
        public short SkillupSkillLineID;
    }
}
