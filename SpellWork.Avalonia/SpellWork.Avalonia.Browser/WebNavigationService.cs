using System.Runtime.InteropServices.JavaScript;
using SpellWork.Services.Navigation;

namespace SpellWork.Avalonia.Browser;

public partial class WebNavigationService : INavigationService
{
    [JSImport("window.history.replaceState", "main.js")]
    internal static partial void ReplaceHistoryState(string title, string href);
    
    public void NavigateTo(string title, string href)
    {
        ReplaceHistoryState(title, href);
    }
}