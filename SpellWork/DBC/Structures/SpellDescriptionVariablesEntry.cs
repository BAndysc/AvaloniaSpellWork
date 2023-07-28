using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellDescriptionVariablesEntry
    {
        [Index(true)]
        public uint ID;
        public string Variables;
    }
}
