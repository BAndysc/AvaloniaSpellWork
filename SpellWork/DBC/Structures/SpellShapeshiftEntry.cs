using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellShapeshiftEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        public sbyte StanceBarOrder;
        [Cardinality(2)]
        public int[] ShapeshiftExclude = new int[2];
        [Cardinality(2)]
        public int[] ShapeshiftMask = new int[2];
    }
}
