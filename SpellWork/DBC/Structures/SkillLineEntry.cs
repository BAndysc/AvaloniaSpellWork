﻿using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SkillLineEntry
    {
        public string DisplayName;
        public string AlternateVerb;
        public string Description;
        public string HordeDisplayName;
        public string OverrideSourceInfoDisplayName;
        [Index(false)]
        public uint ID;
        public sbyte CategoryID;
        public int SpellIconFileID;
        public sbyte CanLink;
        public uint ParentSkillLineID;
        public int ParentTierIndex;
        public int Flags;
        public int SpellBookSpellID;
        public int ExpansionNameSharedStringID;
        public int HordeExpansionNameSharedStringID;
    }
}
