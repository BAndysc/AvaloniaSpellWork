using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using SpellWork.Avalonia.Views;
using SpellWork.ViewModels;

namespace SpellWork.Avalonia;

public class CompileTimeViewLocator : IDataTemplate
{
    private static Dictionary<Type, Func<Control>> mappings = new Dictionary<Type, Func<Control>>()
    {
        { typeof(SpellInfoViewModel), () => new SpellInfoView() },
        { typeof(SpellCompareViewModel), () => new SpellCompareView() },
    };
    
    private Dictionary<Type, Control> cache = new Dictionary<Type, Control>();
    
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var type = data.GetType();

        if (!cache.TryGetValue(type, out var view))
            view = cache[type] = mappings[type]();
        
        return view;
    }

    public bool Match(object? data)
    {
        return data is SpellInfoViewModel || data is SpellCompareViewModel;
    }
}