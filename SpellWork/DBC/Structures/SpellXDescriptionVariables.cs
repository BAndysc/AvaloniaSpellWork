using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

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
