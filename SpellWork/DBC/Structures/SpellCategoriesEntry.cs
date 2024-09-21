﻿using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellCategoriesEntry
    {
        [Index(true)]
        public uint ID;
        public byte DifficultyID;
        public short Category;
        public sbyte DefenseType;
        public sbyte DispelType;
        public sbyte Mechanic;
        public sbyte PreventionType;
        public short StartRecoveryCategory;
        public short ChargeCategory;
        public int SpellID;
    }
}
