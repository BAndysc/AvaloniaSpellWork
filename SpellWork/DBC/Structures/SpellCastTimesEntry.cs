using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellCastTimesEntry
    {
        [Index(true)]
        public uint ID;
        public int Base;
        public int Minimum;
    }
}
