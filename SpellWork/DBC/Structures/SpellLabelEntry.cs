using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellLabelEntry
    {
        [Index(true)]
        public uint ID;
        public uint LabelID;
        public int SpellID;
    }
}
