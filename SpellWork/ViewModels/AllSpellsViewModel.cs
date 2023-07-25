using SpellWork.DBC;

namespace SpellWork.ViewModels;

public class AllSpellsViewModel
{
    private static AllSpellsViewModel? instance;

    public static AllSpellsViewModel Instance
    {
        get
        {
            instance ??= new AllSpellsViewModel();
            return instance;
        }
    }
    
    private List<SpellViewModel> spells = new List<SpellViewModel>();
    
    private AllSpellsViewModel()
    {
        spells.AddRange(DBC.DBC.Spell.Values.Select(spell => new SpellViewModel(spell)));
    }
    
    public IReadOnlyList<SpellViewModel> Spells => spells;
}

public class SpellViewModel
{
    private readonly string toString;
    
    public SpellViewModel(in SpellEntry spell) : this(spell.Entry, spell.SpellName) { }
    
    public SpellViewModel(uint entry, string spellName)
    {
        Entry = entry;
        SpellName = spellName;
        toString = $"{Entry} {SpellName}";
    }

    public uint Entry { get; }
    public string SpellName { get; }

    public override string ToString() => toString;
}