using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData.Binding;
using PropertyChanged.SourceGenerator;
using SpellWork.Spell;

namespace SpellWork.ViewModels;

public partial class SpellCompareViewModel : ObservableObject
{
    [Notify] private IRichTextBox? leftTextView;
    [Notify] private IRichTextBox? rightTextView;
    [Notify] private int leftSpellId;
    [Notify] private int rightSpellId;

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
        
        if (DBC.DBC.SpellInfoStore.ContainsKey(leftSpellId) && DBC.DBC.SpellInfoStore.ContainsKey(rightSpellId))
            SpellCompare.Compare(leftTextView, rightTextView, DBC.DBC.SpellInfoStore[leftSpellId], DBC.DBC.SpellInfoStore[rightSpellId]);
    }
}