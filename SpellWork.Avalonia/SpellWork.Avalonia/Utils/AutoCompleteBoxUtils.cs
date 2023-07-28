using System;
using Avalonia;
using Avalonia.Controls;

namespace SpellWork.Avalonia.Utils;

public class AutoCompleteBoxUtils
{
    public static AvaloniaProperty<Func<string?, object?, bool>> ItemFilterProperty =
        AvaloniaProperty.RegisterAttached<AutoCompleteBoxUtils, AutoCompleteBox, Func<string?, object?, bool>>("ItemFilter");

    public static Func<string?, object?, bool>? GetItemFilter(AutoCompleteBox element) 
        => (Func<string?, object?, bool>?)element.GetValue(ItemFilterProperty);

    public static void SetItemFilter(AutoCompleteBox element, Func<string?, object?, bool> value) 
        => element.SetValue(ItemFilterProperty, value);

    
    public static AvaloniaProperty<Func<string?, object?, string>> TextSelectorProperty =
        AvaloniaProperty.RegisterAttached<AutoCompleteBoxUtils, AutoCompleteBox, Func<string?, object?, string>>("TextSelector");

    public static Func<string?, object?, string>? GetTextSelector(AutoCompleteBox element) 
        => (Func<string?, object?, string>?)element.GetValue(TextSelectorProperty);

    public static void SetTextSelector(AutoCompleteBox element, Func<string?, object?, string> value) 
        => element.SetValue(TextSelectorProperty, value);

    
    
    public static AvaloniaProperty<Func<string?, object?, string>> ItemSelectorProperty =
        AvaloniaProperty.RegisterAttached<AutoCompleteBoxUtils, AutoCompleteBox, Func<string?, object?, string>>("ItemSelector");

    public static Func<string?, object?, string>? GetItemSelector(AutoCompleteBox element) 
        => (Func<string?, object?, string>?)element.GetValue(ItemSelectorProperty);

    public static void SetItemSelector(AutoCompleteBox element, Func<string?, object?, string> value) 
        => element.SetValue(ItemSelectorProperty, value);


    static AutoCompleteBoxUtils()
    {
        ItemFilterProperty.Changed.AddClassHandler<AutoCompleteBox>((sender, args) =>
        {
            if (args.NewValue is Func<string?, object?, bool> itemFilter)
            {
                sender.ItemFilter = (s, t) => itemFilter(s, t);
            }
        });
        
        TextSelectorProperty.Changed.AddClassHandler<AutoCompleteBox>((sender, args) =>
        {
            if (args.NewValue is Func<string?, object?, string> textSelector)
            {
                sender.TextSelector = (s, t) => textSelector(s, t);
            }
        });
        
        ItemSelectorProperty.Changed.AddClassHandler<AutoCompleteBox>((sender, args) =>
        {
            if (args.NewValue is Func<string?, object?, string> itemSelector)
            {
                sender.ItemSelector = (s, t) => itemSelector(s, t);
            }
        });
    }
}