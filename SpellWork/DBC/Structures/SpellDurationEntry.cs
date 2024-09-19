using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellDurationEntry
    {
        [Index(true)]
        public uint ID;
        public int Duration;
        public int MaxDuration;
    }
}
