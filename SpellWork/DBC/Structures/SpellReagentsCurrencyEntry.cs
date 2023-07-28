using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellReagentsCurrencyEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        public ushort CurrencyTypesID;
        public ushort CurrencyCount;
    }
}
