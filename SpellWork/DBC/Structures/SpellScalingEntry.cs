using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellScalingEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        public uint MinScalingLevel;
        public uint MaxScalingLevel;
        public short ScalesFromItemLevel;
    }
}
