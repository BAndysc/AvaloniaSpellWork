using System;
using Avalonia;
using Avalonia.Controls;

namespace SpellWork.Avalonia.Utils;

public class GridUtils
{
    public static AvaloniaProperty<string> RowDefinitionsProperty =
        AvaloniaProperty.RegisterAttached<GridUtils, Grid, string>("RowDefinitions");

    public static string? GetRowDefinitions(Grid element) 
        => (string?)element.GetValue(RowDefinitionsProperty);

    public static void SetRowDefinitions(Grid element, string definition)
        => element.SetCurrentValue(RowDefinitionsProperty, definition);

    
    public static AvaloniaProperty<string> ColumnDefinitionsProperty =
        AvaloniaProperty.RegisterAttached<GridUtils, Grid, string>("ColumnDefinitions");

    public static string? GetColumnDefinitions(Grid element) 
        => (string?)element.GetValue(ColumnDefinitionsProperty);

    public static void SetColumnDefinitions(Grid element, string definition)
        => element.SetCurrentValue(ColumnDefinitionsProperty, definition);

    static GridUtils()
    {
        RowDefinitionsProperty.Changed.AddClassHandler<Grid>((sender, args) =>
        {
            if (args.NewValue is string def)
            {
                sender.RowDefinitions = RowDefinitions.Parse(def);
            }
        });
        
        ColumnDefinitionsProperty.Changed.AddClassHandler<Grid>((sender, args) =>
        {
            if (args.NewValue is string def)
            {
                sender.ColumnDefinitions = ColumnDefinitions.Parse(def);
            }
        });
    }
}