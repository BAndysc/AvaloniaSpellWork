using SpellWork.Services;
using SpellWork.Services.Navigation;

namespace SpellWork;

public static class Globals
{
    public static IProgramArguments ProgramArguments { get; set; } = new NullProgramArguments();
    public static IMessageBoxService MessageBoxService { get; set; }
    public static IFileSystem FileSystem { get; set; }
    public static INavigationService Navigation { get; set; } = new NullNavigationService();
}