using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellNameEntry
    {
        [Index(true)]
        public uint ID;
        public string Name;
    }
}
