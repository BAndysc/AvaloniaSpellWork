using System.Drawing;
using SpellWork.DBC;
using SpellWork.Extensions;

namespace SpellWork.Spell
{
    /// <summary>
    /// Compares two spells
    /// </summary>
    class SpellCompare
    {
        /// <summary>
        /// Search terms
        /// </summary>
        readonly string[] _words = new[] { "=====" };// todo: more wodrs

        /// <summary>
        /// Compares two spells
        /// </summary>
        /// <param name="rtb1">RichTextBox 1 in left</param>
        /// <param name="rtb2">RichTextBox 2 in right</param>
        /// <param name="spell1">Compare Spell 1</param>
        /// <param name="spell2">Compare Spell 2</param>
        public SpellCompare(IRichTextBox rtb1, IRichTextBox rtb2, SpellEntry spell1, SpellEntry spell2)
        {
            new SpellInfo(rtb1, spell1);
            new SpellInfo(rtb2, spell2);

            var strsl = rtb1.Text.Split('\n');
            var strsr = rtb2.Text.Split('\n');

            var pos = 0;
            foreach (var str in strsl)
            {
                pos += str.Length + 1;
                //rtb1.Select(pos - str.Length - 1, pos - 1);

                if (strsr.Contains(str))
                    rtb1.SetBackground(pos - str.Length - 1, str.Length, str.ContainsText(_words) ? Color.Transparent : Color.Cyan); //rtb1.SelectionBackColor = str.ContainsText(_words) ? rtb1.BackColor : Color.Cyan;
                else
                    rtb1.SetBackground(pos - str.Length - 1, str.Length, Color.Salmon);
            }

            pos = 0;
            foreach (var str in strsr)
            {
                pos += str.Length + 1;
                //rtb2.Select(pos - str.Length - 1, pos - 1);

                if (strsl.Contains(str))
                    rtb2.SetBackground(pos - str.Length - 1, str.Length, str.ContainsText(_words) ? Color.Transparent : Color.Cyan); //rtb1.SelectionBackColor = str.ContainsText(_words) ? rtb1.BackColor : Color.Cyan;
                else
                    rtb2.SetBackground(pos - str.Length - 1, str.Length, Color.Salmon);
            }
        }
    }
}
