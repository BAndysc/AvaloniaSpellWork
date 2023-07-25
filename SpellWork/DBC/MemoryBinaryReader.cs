using System.Runtime.InteropServices;
using System.Text;

namespace SpellWork.DBC;

// Faster than BinaryReader
class MemoryBinaryReader
{
    private readonly byte[] array;

    public int Position;
        
    public int Length => array.Length;
        
    public int Left => array.Length - Position;
        
    public MemoryBinaryReader(byte[] array)
    {
        this.array = array;
    }
        
    public byte ReadByte()
    {
        return array[Position++];
    }
        
    public unsafe T ReadStruct<T>() where T : unmanaged
    {
        T returnObject;
        fixed (byte* ptr = &array[Position])
        {
            returnObject = *(T*)ptr;
        }
            
        Position += Marshal.SizeOf<T>();

        return returnObject;
    }
        
    public string ReadCString()
    {
        int length = 0;

        while (array[Position + length] != 0 && Position + length < array.Length)
            length++;
            
        var str = Encoding.UTF8.GetString(array.AsSpan(Position, length));
        Position += length + 1;
        return str;
    }

    public unsafe uint ReadUInt32()
    {
        fixed (byte* ptr = &array[Position])
        {
            Position += 4;
            return *(uint*)ptr;
        }
    }
}