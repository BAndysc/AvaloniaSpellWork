using System.Drawing;
using SpellWork.Extensions;

namespace SpellWork.Spell;

public interface IRichTextBox
{
    void Clear();
    void AppendText(string line);
    Color SelectionColor { set; }
    Font SelectionFont { set; }
    string Text { get; }
    void SetBackground(int start, int length, Color color);
    void SelectAll();
}