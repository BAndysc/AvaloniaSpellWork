using System.Runtime.InteropServices;
using DBCD.IO.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellEquippedItemsEntry
    {
        [Index(true)]
        public uint ID;
        public int SpellID;
        public sbyte EquippedItemClass;
        public int EquippedItemInvTypes;
        public int EquippedItemSubclass;
    }
}
