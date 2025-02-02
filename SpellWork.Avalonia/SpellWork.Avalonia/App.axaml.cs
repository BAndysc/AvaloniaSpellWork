using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using SpellWork.Avalonia.Services;
using SpellWork.Avalonia.Views;
using SpellWork.Properties;
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

        LoadConfig();

        messageBoxService = new MessageBoxService();
        Globals.MessageBoxService = messageBoxService;
        AvaloniaXamlLoader.Load(this);
        Application.Current!.RequestedThemeVariant = ThemeVariant.Light;
    }

    private void LoadConfig()
    {
        if (!File.Exists("SpellWork.config") && File.Exists("SpellWork.dll.config"))
        {
            try
            {
                File.Copy("SpellWork.dll.config", "SpellWork.config");
            } catch (Exception) { }
        }

        var config = new ConfigurationBuilder()
            .AddXmlFile($"{Environment.CurrentDirectory}/SpellWork.config", true)
            .Build();

        foreach (SettingsProperty setting in Properties.Settings.Default.Properties)
        {
            if (config[$"userSettings:SpellWork.Properties.Settings:setting:{setting.Name}:value"] is { } value)
            {
                var convertedValue = Convert.ChangeType(value, setting.PropertyType);
                Settings.Default[setting.Name] = convertedValue;
            }
        }
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
            await Task.Delay(TimeSpan.FromMilliseconds(50));

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