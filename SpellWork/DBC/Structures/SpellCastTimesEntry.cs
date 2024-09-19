using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

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
