using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

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
