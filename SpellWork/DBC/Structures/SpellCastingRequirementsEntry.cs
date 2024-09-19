using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellCastingRequirementsEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        public byte FacingCasterFlags;
        public ushort MinFactionID;
        public int MinReputation;
        public ushort RequiredAreasID;
        public byte RequiredAuraVision;
        public ushort RequiresSpellFocus;
    }
}
