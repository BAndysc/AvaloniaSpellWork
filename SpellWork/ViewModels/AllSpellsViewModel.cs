using SpellWork.DBC;
using SpellWork.Spell;

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
        spells.AddRange(DBC.DBC.SpellInfoStore.Values.OrderBy(x => x.ID).Select(spell => new SpellViewModel(spell)));
    }
    
    public IReadOnlyList<SpellViewModel> Spells => spells;
}

public class SpellViewModel
{
    private readonly SpellInfo spell;

    public SpellViewModel(SpellInfo spell)
    {
        this.spell = spell;
    }
    
    public uint Entry => (uint)spell.ID;
    public string SpellName => spell.Name;
}