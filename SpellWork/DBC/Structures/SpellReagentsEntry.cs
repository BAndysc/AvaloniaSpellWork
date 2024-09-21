﻿using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellReagentsEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        [Cardinality(8)]
        public int[] Reagent = new int[8];
        [Cardinality(8)]
        public short[] ReagentCount = new short[8];
        [Cardinality(8)]
        public short[] ReagentRecraftCount = new short[8];
        [Cardinality(8)]
        public byte[] ReagentSource = new byte[8];
    }
}
