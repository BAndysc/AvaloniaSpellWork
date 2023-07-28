using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellLevelsEntry
    {
        [Index(true)]
        public uint ID;
        public byte DifficultyID;
        public short MaxLevel;
        public byte MaxPassiveAuraLevel;
        public int BaseLevel;
        public int SpellLevel;
        public int SpellID;
    }
}
