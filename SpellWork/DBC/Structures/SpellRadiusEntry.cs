using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SpellRadiusEntry
    {
        [Index(true)]
        public uint ID;
        public float Radius;
        public float RadiusPerLevel;
        public float RadiusMin;
        public float MaxRadius;
    }
}
