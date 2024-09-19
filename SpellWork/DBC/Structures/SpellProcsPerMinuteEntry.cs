using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellProcsPerMinuteEntry
    {
        [Index(true)]
        public uint ID;
        public float BaseProcRate;
        public byte Flags;
    }
}
