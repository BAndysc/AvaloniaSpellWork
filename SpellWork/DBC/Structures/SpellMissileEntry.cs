﻿using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellMissileEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        public byte Flags;
        public float DefaultPitchMin;
        public float DefaultPitchMax;
        public float DefaultSpeedMin;
        public float DefaultSpeedMax;
        public float RandomizeFacingMin;
        public float RandomizeFacingMax;
        public float RandomizePitchMin;
        public float RandomizePitchMax;
        public float RandomizeSpeedMin;
        public float RandomizeSpeedMax;
        public float Gravity;
        public float MaxDuration;
        public float CollisionRadius;
    }
}
