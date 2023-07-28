using System;
using System.Drawing;
using SpellWork.Spell;

namespace SpellWork.Extensions
{
    public static class RichTextBoxExtensions
    {
        public const String DefaultFamily = "Inter";
        public const float  DefaultSize   = 13f;

        public static void AppendFormatLine(this IRichTextBox textbox, string format, params object[] arg0)
        {
            textbox.AppendText(String.Format(format, arg0) + Environment.NewLine);
        }

        public static void AppendFormat(this IRichTextBox textbox, string format, params object[] arg0)
        {
            textbox.AppendText(String.Format(format, arg0));
        }

        public static void AppendLine(this IRichTextBox textbox)
        {
            textbox.AppendText(Environment.NewLine);
        }

        public static void AppendLine(this IRichTextBox textbox, string text)
        {
            textbox.AppendText(text + Environment.NewLine);
        }

        public static void Append(this IRichTextBox textbox, object text)
        {
            textbox.AppendText(text.ToString());
        }

        public static void AppendFormatLineIfNotNull(this IRichTextBox builder, string format, uint arg)
        {
            if (arg != 0)
            {
                builder.AppendFormatLine(format, arg);
            }
        }

        public static void AppendFormatLineIfNotNull(this IRichTextBox builder, string format, float arg)
        {
            if (arg != 0.0f)
            {
                builder.AppendFormatLine(format, arg);
            }
        }

        public static void AppendFormatLineIfNotNull(this IRichTextBox builder, string format, string arg)
        {
            if (arg != String.Empty)
            {
                builder.AppendFormatLine(format, arg);
            }
        }

        public static void AppendFormatIfNotNull(this IRichTextBox builder, string format, uint arg)
        {
            if (arg != 0)
            {
                builder.AppendFormat(format, arg);
            }
        }

        public static void AppendFormatIfNotNull(this IRichTextBox builder, string format, float arg)
        {
            if (arg != 0.0f)
            {
                builder.AppendFormat(format, arg);
            }
        }

        public static void SetStyle(this IRichTextBox textbox, Color color, FontStyle style)
        {
            textbox.SelectionColor = color;
            textbox.SelectionFont = new Font(DefaultFamily, DefaultSize, style);
        }

        public static void SetBold(this IRichTextBox textbox)
        {
            textbox.SelectionFont = new Font(DefaultFamily, DefaultSize, FontStyle.Bold);
        }

        public static void SetDefaultStyle(this IRichTextBox textbox)
        {
            textbox.SelectionFont = new Font(DefaultFamily, DefaultSize, FontStyle.Regular);
            textbox.SelectionColor = Color.Black;
        }
    }

    public struct Font
    {
        public string FontFamily { get; }
        public float Size { get; }
        public FontStyle Style { get; }

        public Font(string fontFamily, float size, FontStyle style)
        {
            FontFamily = fontFamily;
            Size = size;
            Style = style;
        }
    }

    public enum FontStyle
    {
        Bold,
        Regular
    }
}
