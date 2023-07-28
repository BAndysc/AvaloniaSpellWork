namespace SpellWork.Services;

public static class ProgramArgumentsExtensions
{
    public static bool TryGetUInt(this IProgramArguments that, string key, out uint result)
    {
        result = 0;
        if (that.TryGetArgument(key, out var value))
            return uint.TryParse(value, out result);
        return false;
    }
}