using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using SpellWork;
using SpellWork.Avalonia;
using SpellWork.Avalonia.Browser;
using SpellWork.Services;

[assembly: SupportedOSPlatform("browser")]

internal partial class Program
{
    private static async Task Main(string[] args)
    {
        var origin = args.Length >= 1 ? args[0] : "";
        var arguments = args.Length >= 2 ? args[1] : "";
        Globals.ProgramArguments = new UrlProgramArguments(arguments);
        Globals.FileSystem = new WebRemoteFileSystem(origin);
        Globals.Navigation = new WebNavigationService();

        await BuildAvaloniaApp()
            .WithInterFont()
            .StartBrowserAppAsync("out");
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}