using System.Runtime.InteropServices;
using DBFileReaderLib.Attributes;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class SpellCooldownsEntry
    {
        [Index(true)]
        public uint ID;
        public byte DifficultyID;
        public int CategoryRecoveryTime;
        public int RecoveryTime;
        public int StartRecoveryTime;
        public int AuraSpellID;
        public int SpellID;
    }
}
