using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellXDescriptionVariablesEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        public int SpellDescriptionVariablesID;
    }
}
