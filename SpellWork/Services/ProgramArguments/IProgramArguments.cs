namespace SpellWork.Services;

public interface IProgramArguments
{
    bool TryGetArgument(string name, out string? value);
}