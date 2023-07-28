using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class ContentTuningXExpectedEntry
    {
        [Index(true)]
        public uint ID;
        public int ExpectedStatModID;
        public int MinMythicPlusSeasonID;
        public int MaxMythicPlusSeasonID;
        public uint ContentTuningID;
    }
}
