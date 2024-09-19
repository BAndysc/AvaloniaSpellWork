using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

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
