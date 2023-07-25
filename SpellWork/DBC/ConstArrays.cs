public struct Int1Array
{
    public int Length => 1;
    private int val0;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 1; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int1Array arr)
    {
        int[] result = new int[1];
        for (int i = 0; i < 1; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int1Array(int[] arr)
    {
        Int1Array result = new Int1Array();
        for (int i = 0; i < 1; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int2Array
{
    public int Length => 2;
    private int val0;
    private int val1;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 2; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int2Array arr)
    {
        int[] result = new int[2];
        for (int i = 0; i < 2; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int2Array(int[] arr)
    {
        Int2Array result = new Int2Array();
        for (int i = 0; i < 2; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int3Array
{
    public int Length => 3;
    private int val0;
    private int val1;
    private int val2;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 3; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int3Array arr)
    {
        int[] result = new int[3];
        for (int i = 0; i < 3; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int3Array(int[] arr)
    {
        Int3Array result = new Int3Array();
        for (int i = 0; i < 3; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int4Array
{
    public int Length => 4;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 4; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int4Array arr)
    {
        int[] result = new int[4];
        for (int i = 0; i < 4; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int4Array(int[] arr)
    {
        Int4Array result = new Int4Array();
        for (int i = 0; i < 4; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int5Array
{
    public int Length => 5;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 5; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int5Array arr)
    {
        int[] result = new int[5];
        for (int i = 0; i < 5; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int5Array(int[] arr)
    {
        Int5Array result = new Int5Array();
        for (int i = 0; i < 5; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int6Array
{
    public int Length => 6;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 6; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int6Array arr)
    {
        int[] result = new int[6];
        for (int i = 0; i < 6; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int6Array(int[] arr)
    {
        Int6Array result = new Int6Array();
        for (int i = 0; i < 6; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int7Array
{
    public int Length => 7;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 7; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int7Array arr)
    {
        int[] result = new int[7];
        for (int i = 0; i < 7; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int7Array(int[] arr)
    {
        Int7Array result = new Int7Array();
        for (int i = 0; i < 7; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int8Array
{
    public int Length => 8;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 8; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int8Array arr)
    {
        int[] result = new int[8];
        for (int i = 0; i < 8; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int8Array(int[] arr)
    {
        Int8Array result = new Int8Array();
        for (int i = 0; i < 8; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int9Array
{
    public int Length => 9;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    private int val8;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 9; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int9Array arr)
    {
        int[] result = new int[9];
        for (int i = 0; i < 9; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int9Array(int[] arr)
    {
        Int9Array result = new Int9Array();
        for (int i = 0; i < 9; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int10Array
{
    public int Length => 10;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    private int val8;
    private int val9;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 10; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int10Array arr)
    {
        int[] result = new int[10];
        for (int i = 0; i < 10; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int10Array(int[] arr)
    {
        Int10Array result = new Int10Array();
        for (int i = 0; i < 10; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int11Array
{
    public int Length => 11;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    private int val8;
    private int val9;
    private int val10;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 11; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int11Array arr)
    {
        int[] result = new int[11];
        for (int i = 0; i < 11; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int11Array(int[] arr)
    {
        Int11Array result = new Int11Array();
        for (int i = 0; i < 11; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int12Array
{
    public int Length => 12;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    private int val8;
    private int val9;
    private int val10;
    private int val11;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 12; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int12Array arr)
    {
        int[] result = new int[12];
        for (int i = 0; i < 12; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int12Array(int[] arr)
    {
        Int12Array result = new Int12Array();
        for (int i = 0; i < 12; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int13Array
{
    public int Length => 13;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    private int val8;
    private int val9;
    private int val10;
    private int val11;
    private int val12;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 13; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int13Array arr)
    {
        int[] result = new int[13];
        for (int i = 0; i < 13; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int13Array(int[] arr)
    {
        Int13Array result = new Int13Array();
        for (int i = 0; i < 13; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int14Array
{
    public int Length => 14;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    private int val8;
    private int val9;
    private int val10;
    private int val11;
    private int val12;
    private int val13;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 14; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int14Array arr)
    {
        int[] result = new int[14];
        for (int i = 0; i < 14; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int14Array(int[] arr)
    {
        Int14Array result = new Int14Array();
        for (int i = 0; i < 14; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int15Array
{
    public int Length => 15;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    private int val8;
    private int val9;
    private int val10;
    private int val11;
    private int val12;
    private int val13;
    private int val14;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 15; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int15Array arr)
    {
        int[] result = new int[15];
        for (int i = 0; i < 15; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int15Array(int[] arr)
    {
        Int15Array result = new Int15Array();
        for (int i = 0; i < 15; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                case 14: return val14;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                case 14: val14 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Int16Array
{
    public int Length => 16;
    private int val0;
    private int val1;
    private int val2;
    private int val3;
    private int val4;
    private int val5;
    private int val6;
    private int val7;
    private int val8;
    private int val9;
    private int val10;
    private int val11;
    private int val12;
    private int val13;
    private int val14;
    private int val15;
    public bool ContainsElement(int el)
    {
        for (int i = 0; i < 16; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator int[](Int16Array arr)
    {
        int[] result = new int[16];
        for (int i = 0; i < 16; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Int16Array(int[] arr)
    {
        Int16Array result = new Int16Array();
        for (int i = 0; i < 16; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                case 14: return val14;
                case 15: return val15;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                case 14: val14 = value; break;
                case 15: val15 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint1Array
{
    public int Length => 1;
    private uint val0;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 1; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint1Array arr)
    {
        uint[] result = new uint[1];
        for (int i = 0; i < 1; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint1Array(uint[] arr)
    {
        Uint1Array result = new Uint1Array();
        for (int i = 0; i < 1; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint2Array
{
    public int Length => 2;
    private uint val0;
    private uint val1;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 2; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint2Array arr)
    {
        uint[] result = new uint[2];
        for (int i = 0; i < 2; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint2Array(uint[] arr)
    {
        Uint2Array result = new Uint2Array();
        for (int i = 0; i < 2; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint3Array
{
    public int Length => 3;
    private uint val0;
    private uint val1;
    private uint val2;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 3; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint3Array arr)
    {
        uint[] result = new uint[3];
        for (int i = 0; i < 3; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint3Array(uint[] arr)
    {
        Uint3Array result = new Uint3Array();
        for (int i = 0; i < 3; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint4Array
{
    public int Length => 4;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 4; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint4Array arr)
    {
        uint[] result = new uint[4];
        for (int i = 0; i < 4; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint4Array(uint[] arr)
    {
        Uint4Array result = new Uint4Array();
        for (int i = 0; i < 4; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint5Array
{
    public int Length => 5;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 5; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint5Array arr)
    {
        uint[] result = new uint[5];
        for (int i = 0; i < 5; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint5Array(uint[] arr)
    {
        Uint5Array result = new Uint5Array();
        for (int i = 0; i < 5; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint6Array
{
    public int Length => 6;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 6; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint6Array arr)
    {
        uint[] result = new uint[6];
        for (int i = 0; i < 6; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint6Array(uint[] arr)
    {
        Uint6Array result = new Uint6Array();
        for (int i = 0; i < 6; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint7Array
{
    public int Length => 7;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 7; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint7Array arr)
    {
        uint[] result = new uint[7];
        for (int i = 0; i < 7; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint7Array(uint[] arr)
    {
        Uint7Array result = new Uint7Array();
        for (int i = 0; i < 7; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint8Array
{
    public int Length => 8;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 8; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint8Array arr)
    {
        uint[] result = new uint[8];
        for (int i = 0; i < 8; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint8Array(uint[] arr)
    {
        Uint8Array result = new Uint8Array();
        for (int i = 0; i < 8; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint9Array
{
    public int Length => 9;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    private uint val8;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 9; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint9Array arr)
    {
        uint[] result = new uint[9];
        for (int i = 0; i < 9; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint9Array(uint[] arr)
    {
        Uint9Array result = new Uint9Array();
        for (int i = 0; i < 9; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint10Array
{
    public int Length => 10;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    private uint val8;
    private uint val9;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 10; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint10Array arr)
    {
        uint[] result = new uint[10];
        for (int i = 0; i < 10; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint10Array(uint[] arr)
    {
        Uint10Array result = new Uint10Array();
        for (int i = 0; i < 10; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint11Array
{
    public int Length => 11;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    private uint val8;
    private uint val9;
    private uint val10;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 11; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint11Array arr)
    {
        uint[] result = new uint[11];
        for (int i = 0; i < 11; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint11Array(uint[] arr)
    {
        Uint11Array result = new Uint11Array();
        for (int i = 0; i < 11; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint12Array
{
    public int Length => 12;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    private uint val8;
    private uint val9;
    private uint val10;
    private uint val11;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 12; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint12Array arr)
    {
        uint[] result = new uint[12];
        for (int i = 0; i < 12; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint12Array(uint[] arr)
    {
        Uint12Array result = new Uint12Array();
        for (int i = 0; i < 12; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint13Array
{
    public int Length => 13;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    private uint val8;
    private uint val9;
    private uint val10;
    private uint val11;
    private uint val12;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 13; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint13Array arr)
    {
        uint[] result = new uint[13];
        for (int i = 0; i < 13; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint13Array(uint[] arr)
    {
        Uint13Array result = new Uint13Array();
        for (int i = 0; i < 13; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint14Array
{
    public int Length => 14;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    private uint val8;
    private uint val9;
    private uint val10;
    private uint val11;
    private uint val12;
    private uint val13;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 14; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint14Array arr)
    {
        uint[] result = new uint[14];
        for (int i = 0; i < 14; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint14Array(uint[] arr)
    {
        Uint14Array result = new Uint14Array();
        for (int i = 0; i < 14; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint15Array
{
    public int Length => 15;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    private uint val8;
    private uint val9;
    private uint val10;
    private uint val11;
    private uint val12;
    private uint val13;
    private uint val14;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 15; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint15Array arr)
    {
        uint[] result = new uint[15];
        for (int i = 0; i < 15; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint15Array(uint[] arr)
    {
        Uint15Array result = new Uint15Array();
        for (int i = 0; i < 15; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                case 14: return val14;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                case 14: val14 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Uint16Array
{
    public int Length => 16;
    private uint val0;
    private uint val1;
    private uint val2;
    private uint val3;
    private uint val4;
    private uint val5;
    private uint val6;
    private uint val7;
    private uint val8;
    private uint val9;
    private uint val10;
    private uint val11;
    private uint val12;
    private uint val13;
    private uint val14;
    private uint val15;
    public bool ContainsElement(uint el)
    {
        for (int i = 0; i < 16; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator uint[](Uint16Array arr)
    {
        uint[] result = new uint[16];
        for (int i = 0; i < 16; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Uint16Array(uint[] arr)
    {
        Uint16Array result = new Uint16Array();
        for (int i = 0; i < 16; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public uint this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                case 14: return val14;
                case 15: return val15;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                case 14: val14 = value; break;
                case 15: val15 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float1Array
{
    public int Length => 1;
    private float val0;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 1; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float1Array arr)
    {
        float[] result = new float[1];
        for (int i = 0; i < 1; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float1Array(float[] arr)
    {
        Float1Array result = new Float1Array();
        for (int i = 0; i < 1; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float2Array
{
    public int Length => 2;
    private float val0;
    private float val1;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 2; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float2Array arr)
    {
        float[] result = new float[2];
        for (int i = 0; i < 2; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float2Array(float[] arr)
    {
        Float2Array result = new Float2Array();
        for (int i = 0; i < 2; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float3Array
{
    public int Length => 3;
    private float val0;
    private float val1;
    private float val2;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 3; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float3Array arr)
    {
        float[] result = new float[3];
        for (int i = 0; i < 3; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float3Array(float[] arr)
    {
        Float3Array result = new Float3Array();
        for (int i = 0; i < 3; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float4Array
{
    public int Length => 4;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 4; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float4Array arr)
    {
        float[] result = new float[4];
        for (int i = 0; i < 4; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float4Array(float[] arr)
    {
        Float4Array result = new Float4Array();
        for (int i = 0; i < 4; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float5Array
{
    public int Length => 5;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 5; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float5Array arr)
    {
        float[] result = new float[5];
        for (int i = 0; i < 5; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float5Array(float[] arr)
    {
        Float5Array result = new Float5Array();
        for (int i = 0; i < 5; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float6Array
{
    public int Length => 6;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 6; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float6Array arr)
    {
        float[] result = new float[6];
        for (int i = 0; i < 6; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float6Array(float[] arr)
    {
        Float6Array result = new Float6Array();
        for (int i = 0; i < 6; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float7Array
{
    public int Length => 7;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 7; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float7Array arr)
    {
        float[] result = new float[7];
        for (int i = 0; i < 7; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float7Array(float[] arr)
    {
        Float7Array result = new Float7Array();
        for (int i = 0; i < 7; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float8Array
{
    public int Length => 8;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 8; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float8Array arr)
    {
        float[] result = new float[8];
        for (int i = 0; i < 8; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float8Array(float[] arr)
    {
        Float8Array result = new Float8Array();
        for (int i = 0; i < 8; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float9Array
{
    public int Length => 9;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    private float val8;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 9; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float9Array arr)
    {
        float[] result = new float[9];
        for (int i = 0; i < 9; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float9Array(float[] arr)
    {
        Float9Array result = new Float9Array();
        for (int i = 0; i < 9; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float10Array
{
    public int Length => 10;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    private float val8;
    private float val9;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 10; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float10Array arr)
    {
        float[] result = new float[10];
        for (int i = 0; i < 10; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float10Array(float[] arr)
    {
        Float10Array result = new Float10Array();
        for (int i = 0; i < 10; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float11Array
{
    public int Length => 11;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    private float val8;
    private float val9;
    private float val10;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 11; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float11Array arr)
    {
        float[] result = new float[11];
        for (int i = 0; i < 11; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float11Array(float[] arr)
    {
        Float11Array result = new Float11Array();
        for (int i = 0; i < 11; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float12Array
{
    public int Length => 12;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    private float val8;
    private float val9;
    private float val10;
    private float val11;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 12; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float12Array arr)
    {
        float[] result = new float[12];
        for (int i = 0; i < 12; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float12Array(float[] arr)
    {
        Float12Array result = new Float12Array();
        for (int i = 0; i < 12; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float13Array
{
    public int Length => 13;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    private float val8;
    private float val9;
    private float val10;
    private float val11;
    private float val12;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 13; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float13Array arr)
    {
        float[] result = new float[13];
        for (int i = 0; i < 13; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float13Array(float[] arr)
    {
        Float13Array result = new Float13Array();
        for (int i = 0; i < 13; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float14Array
{
    public int Length => 14;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    private float val8;
    private float val9;
    private float val10;
    private float val11;
    private float val12;
    private float val13;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 14; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float14Array arr)
    {
        float[] result = new float[14];
        for (int i = 0; i < 14; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float14Array(float[] arr)
    {
        Float14Array result = new Float14Array();
        for (int i = 0; i < 14; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float15Array
{
    public int Length => 15;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    private float val8;
    private float val9;
    private float val10;
    private float val11;
    private float val12;
    private float val13;
    private float val14;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 15; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float15Array arr)
    {
        float[] result = new float[15];
        for (int i = 0; i < 15; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float15Array(float[] arr)
    {
        Float15Array result = new Float15Array();
        for (int i = 0; i < 15; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                case 14: return val14;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                case 14: val14 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
public struct Float16Array
{
    public int Length => 16;
    private float val0;
    private float val1;
    private float val2;
    private float val3;
    private float val4;
    private float val5;
    private float val6;
    private float val7;
    private float val8;
    private float val9;
    private float val10;
    private float val11;
    private float val12;
    private float val13;
    private float val14;
    private float val15;
    public bool ContainsElement(float el)
    {
        for (int i = 0; i < 16; ++i)
        {
            if (this[i] == el) return true;
        }
        return false;
    }
    public static implicit operator float[](Float16Array arr)
    {
        float[] result = new float[16];
        for (int i = 0; i < 16; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public static implicit operator Float16Array(float[] arr)
    {
        Float16Array result = new Float16Array();
        for (int i = 0; i < 16; ++i)
        {
            result[i] = arr[i];
        }
        return result;
    }
    public float this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return val0;
                case 1: return val1;
                case 2: return val2;
                case 3: return val3;
                case 4: return val4;
                case 5: return val5;
                case 6: return val6;
                case 7: return val7;
                case 8: return val8;
                case 9: return val9;
                case 10: return val10;
                case 11: return val11;
                case 12: return val12;
                case 13: return val13;
                case 14: return val14;
                case 15: return val15;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: val0 = value; break;
                case 1: val1 = value; break;
                case 2: val2 = value; break;
                case 3: val3 = value; break;
                case 4: val4 = value; break;
                case 5: val5 = value; break;
                case 6: val6 = value; break;
                case 7: val7 = value; break;
                case 8: val8 = value; break;
                case 9: val9 = value; break;
                case 10: val10 = value; break;
                case 11: val11 = value; break;
                case 12: val12 = value; break;
                case 13: val13 = value; break;
                case 14: val14 = value; break;
                case 15: val15 = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}
