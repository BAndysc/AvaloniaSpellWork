using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData.Binding;
using PropertyChanged.SourceGenerator;
using SpellWork.Spell;

namespace SpellWork.ViewModels;

public partial class SpellCompareViewModel : ObservableObject
{
    [Notify] private IRichTextBox? leftTextView;
    [Notify] private IRichTextBox? rightTextView;
    [Notify] private uint leftSpellId;
    [Notify] private uint rightSpellId;

    public SpellCompareViewModel()
    {
        this.WhenValueChanged(x => x.LeftSpellId, false)
            .Subscribe(_ => DoCompare());
        this.WhenValueChanged(x => x.RightSpellId, false)
            .Subscribe(_ => DoCompare());
    }

    private void DoCompare()
    {
        if (leftTextView == null || rightTextView == null)
            return;
        
        if (DBC.DBC.Spell.TryGetValue(leftSpellId, out var leftSpell) && DBC.DBC.Spell.TryGetValue(rightSpellId, out var rightSpell))
            new SpellCompare(leftTextView, rightTextView, leftSpell, rightSpell);
    }
}