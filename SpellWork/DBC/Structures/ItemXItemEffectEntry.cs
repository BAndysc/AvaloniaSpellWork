using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class ItemXItemEffectEntry
    {
        [Index(true)]
        public uint ID;
        public int ItemEffectID;
        public int ItemID;
    }
}
