using SpellWork.Extensions;

namespace SpellWork.ViewModels;

public readonly struct EnumViewModel<T> where T : Enum
{
    private static string GetEnumDescription(Type type, Enum value)
    {
        var name = value.ToString();
        var field = type.GetField(name);
        var customAttribute = field!.GetCustomAttributes(typeof(FullNameAttribute), false);
        return customAttribute.Length > 0 ? ((FullNameAttribute)customAttribute[0]).FullName : name;
    }
    
    public EnumViewModel(T value, string name)
    {
        Value = value;
        Name = name;
    }
    
    public static EnumViewModel<T> Create(T value)
    {
        var name = GetEnumDescription(typeof(T), value);
        return new EnumViewModel<T>(value, "(" + Convert.ToInt64(value) + ") " + name);
    }

    public static EnumViewModel<T> CreateNoNumber(T value)
    {
        var name = GetEnumDescription(typeof(T), value);
        return new EnumViewModel<T>(value, name);
    }

    public T Value { get; }
    public string Name { get; }

    public override string ToString() => Name;
}