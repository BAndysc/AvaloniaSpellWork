using SpellWork.Services;
using UIKit;

namespace SpellWork.Avalonia.iOS;

public class Application
{
    // This is the main entry point of the application.
    static void Main(string[] args)
    {
        Globals.FileSystem = new RemoteFileSystem();

        // if you want to use a different Application Delegate class from "AppDelegate"
        // you can specify it here.
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}