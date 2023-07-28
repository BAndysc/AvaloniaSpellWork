using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellTargetRestrictionsEntry
    {
        [Index(true)]
        public uint ID;
        public byte DifficultyID;
        public float ConeDegrees;
        public byte MaxTargets;
        public uint MaxTargetLevel;
        public short TargetCreatureType;
        public int Targets;
        public float Width;
        public int SpellID;
    }
}
