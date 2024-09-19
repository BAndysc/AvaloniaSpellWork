using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class ItemEffectEntry
    {
        [Index(true)]
        public uint ID;
        public byte LegacySlotIndex;
        public sbyte TriggerType;
        public short Charges;
        public int CoolDownMSec;
        public int CategoryCoolDownMSec;
        public ushort SpellCategoryID;
        public int SpellID;
        public ushort ChrSpecializationID;

        // Helper
        public ItemSparseEntry Item { get; set; }
        public int ItemID { get; set; }
    }
}
