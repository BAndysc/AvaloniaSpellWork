namespace SpellWork.Services;

public class CommandLineProgramArguments : IProgramArguments
{
    private Dictionary<string, string?> arguments = new();
    
    public CommandLineProgramArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            var arg = args[i].Trim();
            if (arg.StartsWith("-"))
            {
                var key = arg.Substring(1);
                string? value = null;
                if (i + 1 < args.Length)
                    value = args[++i].Trim();
                arguments.Add(key, value);
            }
        }
    }
    
    public bool TryGetArgument(string name, out string? value)
    {
        return arguments.TryGetValue(name, out value);
    }
}