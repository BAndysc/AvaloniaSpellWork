using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellClassOptionsEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        public uint ModalNextSpell;
        public byte SpellClassSet;
        [Cardinality(4)]
        public int[] SpellClassMask = new int[4];
    }
}
