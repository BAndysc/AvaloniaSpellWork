using System;
using Avalonia;
using Avalonia.Controls;
using SpellWork.Spell;

namespace SpellWork.Avalonia.Utils;

public class RichTextBoxEmulator : SelectableTextBlock
{
    protected override Type StyleKeyOverride => typeof(SelectableTextBlock);
    
    public static readonly StyledProperty<IRichTextBox> SourceProperty = AvaloniaProperty.Register<RichTextBoxEmulator, IRichTextBox>("Source");

    public IRichTextBox Source
    {
        get => GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly AttachedProperty<RunTooltip> RunTagProperty = AvaloniaProperty.RegisterAttached<RichTextBoxEmulator, StyledElement, RunTooltip>("RunTag");
    public static RunTooltip GetRunTag(StyledElement element) => element.GetValue(RunTagProperty);
    public static void SetRunTag(StyledElement element, RunTooltip value) => element.SetValue(RunTagProperty, value);

    public RichTextBoxEmulator()
    {
        Source = new AvaloniaRichTextBox(this);
    }
}

public struct RunTooltip
{
    public RunTooltip(string header, string text)
    {
        Header = header;
        Text = text;
    }

    public string Header { get; }
    public string Text { get; }
}