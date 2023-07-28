namespace SpellWork.Services;

public class NullProgramArguments : IProgramArguments
{
    public bool TryGetArgument(string name, out string? value)
    {
        value = null;
        return false;
    }
}