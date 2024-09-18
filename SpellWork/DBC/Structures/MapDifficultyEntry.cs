using DBFileReaderLib.Attributes;
using System;
using System.Runtime.InteropServices;

namespace SpellWork.DBC.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public class MapDifficultyEntry : IComparable
    {
        [Index(true)]
        public uint ID;
        public string Message;
        public int DifficultyID;
        public int LockID;
        public sbyte ResetInterval;
        public int MaxPlayers;
        public byte ItemContext;
        public int ItemContextPickerID;
        public int Flags;
        public int ContentTuningID;
        public int MapID;

        public int CompareTo(object obj)
        {
            return obj is MapDifficultyEntry m ? ID.CompareTo(m.ID) : 1;
        }
    }
}
