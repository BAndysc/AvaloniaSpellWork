using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class ContentTuningEntry
    {
        [Index(false)]
        public uint ID;
        public int Flags;
        public int ExpansionID;
        public int MinLevel;
        public int MaxLevel;
        public int MinLevelType;
        public int MaxLevelType;
        public int TargetLevelDelta;
        public int TargetLevelMaxDelta;
        public int TargetLevelMin;
        public int TargetLevelMax;
        public int MinItemLevel;
    }
}
