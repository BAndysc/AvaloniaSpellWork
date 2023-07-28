using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Documents;
using Avalonia.Media;
using SpellWork.Extensions;
using SpellWork.Spell;
using Color = System.Drawing.Color;
using FontStyle = SpellWork.Extensions.FontStyle;

namespace SpellWork.Avalonia.Utils;

public class AvaloniaRichTextBox : IRichTextBox
{
    private SelectableTextBlock textBlock;

    public AvaloniaRichTextBox(SelectableTextBlock textBlock)
    {
        this.textBlock = textBlock;
    }

    public void Clear()
    {
        textBlock.Inlines?.Clear();
        SelectionColor = Color.Black;
        SelectionFont = new Font("Inter", 13, FontStyle.Regular);
    }
    
    public void AppendText(string line)
    {
        textBlock.Inlines?.Add(new Run(line)
        {
            Foreground = new SolidColorBrush(new global::Avalonia.Media.Color(SelectionColor.A, SelectionColor.R, SelectionColor.G, SelectionColor.B)),
            //FontFamily = new FontFamily(SelectionFont.FontFamily),
            FontSize = SelectionFont.Size,
            FontWeight = SelectionFont.Style == FontStyle.Bold ? FontWeight.Bold : FontWeight.Normal
        });
    }

    public Color SelectionColor { get; set; } = Color.Black;
    public Font SelectionFont { get; set; } = new Font("Inter", 9, FontStyle.Regular);

    public string Text => textBlock.Inlines!.Text ?? "";

    public void SetBackground(int start, int length, Color color)
    {
        int pos = 0;
        for (var index = 0; index < textBlock.Inlines!.Count; index++)
        {
            var inline = textBlock.Inlines![index];
            if (inline is Run run && run.Text != null)
            {
                int runStart = pos;
                int runEnd = pos + run.Text.Length;
                if (runStart == start && runEnd < start + length)
                {
                    // run is completely selected
                    run.Background = new SolidColorBrush(new global::Avalonia.Media.Color(color.A, color.R, color.G, color.B));
                }
                else if (runStart >= start && runStart < start + length 
                         || runEnd >= start && runEnd < start + length
                         || runStart < start && runEnd > start + length)
                {
                    var partBeforeOrNull = runStart < start ? run.Text.Substring(0, start - runStart) : null;
                    var middleStart = partBeforeOrNull?.Length ?? 0;
                    var middleLength = Math.Min(length, run.Text.Length - (partBeforeOrNull?.Length ?? 0));
                    var partMiddle = run.Text.Substring(partBeforeOrNull?.Length ?? 0, middleLength);
                    var partAfterOrNull = runEnd > start + length ? run.Text.Substring(middleStart + middleLength) : null;
                    
                    textBlock.Inlines!.RemoveAt(index);

                    if (partBeforeOrNull != null)
                    {
                        textBlock.Inlines!.Insert(index, new Run(partBeforeOrNull)
                        {
                            Foreground = run.Foreground,
                            //FontFamily = run.FontFamily,
                            FontSize = run.FontSize,
                            FontWeight = run.FontWeight
                        });
                        index++;                        
                    }
                    textBlock.Inlines!.Insert(index, new Run(partMiddle)
                    {
                        Foreground = run.Foreground,
                        Background = new SolidColorBrush(new global::Avalonia.Media.Color(color.A, color.R, color.G, color.B)),
                        //FontFamily = run.FontFamily,
                        FontSize = run.FontSize,
                        FontWeight = run.FontWeight
                    });
                    if (partAfterOrNull != null)
                    {
                        textBlock.Inlines!.Insert(index + 1, new Run(partAfterOrNull)
                        {
                            Foreground = run.Foreground,
                            Background = run.Background,
                            //FontFamily = run.FontFamily,
                            FontSize = run.FontSize,
                            FontWeight = run.FontWeight
                        });
                        index += 1;
                    }
                }

                pos += run.Text.Length;
            }
        }
    }

    public void SelectAll()
    {
        textBlock.SelectionStart = 0;
        textBlock.SelectionEnd = textBlock.Inlines?.Text?.Length ?? 0;
    }
}