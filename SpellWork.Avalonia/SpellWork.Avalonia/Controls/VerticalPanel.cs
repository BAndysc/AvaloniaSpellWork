using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

namespace SpellWork.Avalonia.Controls;

public class VerticalPanel : Panel
{
    
    public static readonly AttachedProperty<bool> FlexProperty = AvaloniaProperty.RegisterAttached<VerticalPanel, Control, bool>("Flex");
    public static bool GetFlex(Control element) => element.GetValue(FlexProperty);
    public static void SetFlex(Control element, bool value) => element.SetValue(FlexProperty, value);
    
    protected override Size MeasureOverride(Size availableSize)
    {
        double width = 0;
        double height = 0;

        var visualChildren = VisualChildren;
        var visualCount = visualChildren.Count;

        for (var i = 0; i < visualCount; i++)
        {
            Visual visual = visualChildren[i];

            var isFlex = GetFlex((Control)visual);
            var minHeight = (visual as Control)!.MinHeight;
            
            if (visual is Layoutable layoutable)
            {
                layoutable.Measure(new Size(availableSize.Width, availableSize.Height - height));
                width = Math.Max(width, layoutable.DesiredSize.Width);
                height += isFlex ? minHeight : layoutable.DesiredSize.Height;
            }
        }

        return new Size(width, height);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        double y = 0;
        var visualChildren = VisualChildren;
        var visualCount = visualChildren.Count;

        double desiredHeight = 0;
        int flexCount = 0;
        for (var i = 0; i < visualCount; i++)
        {
            Visual visual = visualChildren[i];

            var isFlex = GetFlex((Control)visual);
            if (visual is Layoutable layoutable)
            {
                desiredHeight += isFlex ? 0 : layoutable.DesiredSize.Height;
                flexCount += isFlex ? 1 : 0;
            }
        }

        double leftSpace = Math.Max(0, finalSize.Height - desiredHeight);
        double spacePerFlex = flexCount == 0 ? 0 : leftSpace / flexCount;
        
        for (var i = 0; i < visualCount; i++)
        {
            Visual visual = visualChildren[i];

            var isFlex = GetFlex((Control)visual);
            var minHeight = (visual as Control)!.MinHeight;

            if (visual is Layoutable layoutable)
            {
                double height = isFlex ? Math.Max(minHeight, spacePerFlex) : layoutable.DesiredSize.Height;
                var arrangeRect = new Rect(0, y, finalSize.Width, height);
                y += height;
                layoutable.Arrange(arrangeRect);
                layoutable.MaxHeight = height; // <- hack for DataGrid
            }
        }

        return finalSize;
    }
}