using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using SpellWork.Avalonia.Services;
using SpellWork.Avalonia.Views;
using SpellWork.Services;
using SpellWork.ViewModels;

namespace SpellWork.Avalonia;

public partial class App : Application
{
    private MessageBoxService messageBoxService = null!;
    
    public override void Initialize()
    {
        // required to work in Release mode in browser, as this is the only valid culture info
        // and if it is set to invariant, then FluentAvalonia tries to initialize English culture, which is missing
        Thread.CurrentThread.CurrentCulture = new CultureInfo("");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("");
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("");

        messageBoxService = new MessageBoxService();
        Globals.MessageBoxService = messageBoxService;
        AvaloniaXamlLoader.Load(this);
        Application.Current!.RequestedThemeVariant = ThemeVariant.Light;
    }

    public override void OnFrameworkInitializationCompleted()
    {
        MainWindow? window = null;
        SingleViewRoot? singleViewRoot = null;
        
        var loadingViewModel = new LoadingViewModel();
        var loadingView = new LoadingView() { DataContext = loadingViewModel };
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = window = new MainWindow()
            {
                Content = loadingView
            };
            window.Loaded += (_, _) => messageBoxService.InitializeTopLevel(window);
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = singleViewRoot = new SingleViewRoot()
            {
                Content = loadingView
            };
            singleViewRoot.Loaded += (_, _) => messageBoxService.InitializeTopLevel(singleViewRoot);
        }

        base.OnFrameworkInitializationCompleted();
        
        async Task Init()
        {
            await loadingViewModel.LoadTask();

            var content = new MainView() { DataContext = new MainViewViewModel() };
            if (window != null)
                window.Content = content;
            else
                singleViewRoot!.Content = content;
        }

        Init().ContinueWith(x =>
        {
            Console.WriteLine(x.Exception);
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
}