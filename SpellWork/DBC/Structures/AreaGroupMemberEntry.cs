using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class AreaGroupMemberEntry
    {
        [Index(true)]
        public uint ID;
        public ushort AreaID;
        public ushort AreaGroupID;
    }
}
