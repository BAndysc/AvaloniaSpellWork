using SpellWork.Spell;
using SpellWork.WinForms.Extensions;
using Font = SpellWork.Extensions.Font;
using FontStyle = SpellWork.Extensions.FontStyle;

namespace SpellWork.WinForms.Utils;

public class RichTextBoxWrapper : IRichTextBox
{
    private readonly RichTextBox rtb;

    public RichTextBoxWrapper(RichTextBox rtb)
    {
        this.rtb = rtb;
    }

    public void Clear() => rtb.Clear();

    public void AppendText(string line) => rtb.AppendLine(line);

    public Color SelectionColor
    {
        set => rtb.SelectionColor = value;
    }

    public Font SelectionFont
    {
        set => rtb.SelectionFont = new System.Drawing.Font(value.FontFamily, value.Size,
            value.Style == FontStyle.Bold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
    }
    public void SelectAll() => rtb.SelectAll();
}
