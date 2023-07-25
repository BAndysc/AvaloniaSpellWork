namespace SpellWork.Services;

public class UrlProgramArguments : IProgramArguments
{
    private Dictionary<string, string?> arguments = new();

    public UrlProgramArguments(string args)
    {
        args = args.Trim().TrimStart('?');
        var pairs = args.Split('&');
        foreach (var pair in pairs)
        {
            var keyValue = pair.Split('=');
            if (keyValue.Length == 2)
                arguments.Add(keyValue[0], keyValue[1]);
        }
    }
    
    public bool TryGetArgument(string name, out string? value)
    {
        return arguments.TryGetValue(name, out value);
    }
}