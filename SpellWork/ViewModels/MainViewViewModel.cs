using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData.Binding;
using PropertyChanged.SourceGenerator;

namespace SpellWork.ViewModels;

public partial class MainViewViewModel : ObservableObject
{
    [Notify] private TabViewModel selectedTab;
    [Notify] private SpellViewModel selectedQuickSpellSelect;

    private SpellInfoViewModel spellInfoViewModel;
    
    public ObservableCollection<TabViewModel> Tabs { get; } = new ObservableCollection<TabViewModel>();

    public IReadOnlyList<SpellViewModel> AllSpells { get; }

    public Func<string?, object, bool> ItemFilter { get; }
    
    public Func<string?, object, string?> TextSelector { get; }
    
    public MainViewViewModel()
    {
        spellInfoViewModel = new SpellInfoViewModel();
        Tabs.Add(new TabViewModel("Spell info", spellInfoViewModel));
        Tabs.Add(new TabViewModel("Spell compare", new SpellCompareViewModel()));

        AllSpells = AllSpellsViewModel.Instance.Spells;

        ItemFilter = (search, item) =>
        {
            if (search == null)
                return true;
            
            if ((item as SpellViewModel)!.SpellName.Contains(search, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        };
        
        TextSelector = (search, item) =>
        {
            if (search == null ||
                item is not SpellViewModel spell)
                return search;

            return spell.Entry + " " + spell.SpellName;
        };
        
        selectedTab = Tabs[0];

        this.WhenValueChanged(x => x.SelectedQuickSpellSelect, false)
            .Subscribe(spell =>
            {
                if (spell != null)
                {
                    spellInfoViewModel.SelectedSpell = spell;
                    SelectedTab = Tabs[0];
                }
            });
    }
}

public class TabViewModel
{
    public TabViewModel(string header, object? dataContext)
    {
        Header = header;
        DataContext = dataContext;
    }

    public string Header { get; }
    public object? DataContext { get; }
}