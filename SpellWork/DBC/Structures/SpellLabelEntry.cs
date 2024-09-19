using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

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
