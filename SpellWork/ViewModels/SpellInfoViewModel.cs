using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData.Binding;
using PropertyChanged.SourceGenerator;
using SpellWork.DBC;
using SpellWork.Extensions;
using SpellWork.Services;
using SpellWork.Spell;

namespace SpellWork.ViewModels;

public partial class SpellInfoViewModel : ObservableObject
{
    public List<StructFilterTypeViewModel> SpellEntryFilterTypes { get; set; } = new();

    public ObservableCollectionExtended<SpellViewModel> Spells { get; } = new ObservableCollectionExtended<SpellViewModel>();

    private SpellViewModel? selectedSpell = null;
    [Notify] private string searchText = "";
    [Notify] private int searchIcon;
    [Notify] private int searchAttribute;
    [Notify] private EnumViewModel<SpellFamilyNames>? spellFamilyName;
    [Notify] private EnumViewModel<AuraType>? auraType;
    [Notify] private EnumViewModel<SpellEffects>? spellEffect;
    [Notify] private EnumViewModel<Targets>? targetA;
    [Notify] private EnumViewModel<Targets>? targetB;
    
    public List<EnumViewModel<SpellFamilyNames>> SpellFamilyNames { get; }
    public List<EnumViewModel<AuraType>> AuraTypes { get; }
    public List<EnumViewModel<SpellEffects>> SpellEffects { get; }
    public List<EnumViewModel<Targets>> Targets { get; }
    public List<EnumViewModel<CompareType>> CompareTypes { get; }
    
    // advanced
    private List<AdvancedFilterViewModel<SpellEntry>> advancedSpellInfoFilters = new();
    public ObservableCollection<AdvancedFilterViewModel> AdvancedFilters { get; } = new();
    
    [Notify] private IRichTextBox? textView;

    public SpellViewModel? SelectedSpell
    {
        get => selectedSpell;
        set
        {
            if (value == null)
                return;
            SetProperty(ref selectedSpell, value);
        }
    }
    
    public ICommand DoSearchCommand { get; }
    public ICommand SelectAllTextCommand { get; }

    public SpellInfoViewModel()
    {
        FillStructFilterTypes<SpellEntry>(SpellEntryFilterTypes);
        
        SpellFamilyNames = Enum.GetValues<SpellFamilyNames>().Select(EnumViewModel<SpellFamilyNames>.Create).ToList();
        AuraTypes = Enum.GetValues<AuraType>().Select(EnumViewModel<AuraType>.Create).ToList();
        SpellEffects = Enum.GetValues<SpellEffects>().Select(EnumViewModel<SpellEffects>.Create).ToList();
        Targets = Enum.GetValues<Targets>().Select(EnumViewModel<Targets>.Create).ToList();
        CompareTypes = Enum.GetValues<CompareType>().Select(EnumViewModel<CompareType>.CreateNoNumber).ToList();
        
        for (int i = 0; i < 2; ++i)
        {
            var filter = new AdvancedFilterViewModel<SpellEntry>(SpellEntryFilterTypes, CompareTypes);
            advancedSpellInfoFilters.Add(filter);
            AdvancedFilters.Add(filter);
            filter.PropertyChanged += (_, _) => FilterAndSearch();
        }

        this.WhenValueChanged(x => x.SelectedSpell, false)
            .Subscribe(spell =>
            {
                if (spell != null && textView != null)
                {
                    Globals.Navigation.NavigateTo(spell.SpellName, $"?spell={spell.Entry}");
                    new SpellInfo(textView, DBC.DBC.Spell[spell.Entry]);
                }
            });
        
        this.WhenAnyPropertyChanged(nameof(SpellFamilyName),
            nameof(AuraType),
            nameof(SpellEffect),
            nameof(TargetA),
            nameof(TargetB)).Subscribe(_ => FilterAndSearch().ListenErrors());
        
        DoSearchCommand = new RelayCommand(() => FilterAndSearch().ListenErrors());
        SelectAllTextCommand = new RelayCommand(() => TextView.SelectAll());
        FilterAndSearch().ListenErrors();

        if (Globals.ProgramArguments.TryGetUInt("spell", out var spellId) &&
            Spells.FirstOrDefault(x => x.Entry == spellId) is { } spellEntry)
            SelectedSpell = spellEntry;
    }

    private CancellationTokenSource? pendingSearch;
    private async Task FilterAndSearch()
    {
        if (pendingSearch != null)
            pendingSearch.Cancel();

        var token = new CancellationTokenSource();
        pendingSearch = token;

        async Task FilterCore(CancellationToken cancellationToken)
        {
            var name = searchText;
            var id = name.ToUInt32();
            var ic = searchIcon;
            var at = searchAttribute;

            // advanced

            var bFamilyNames = spellFamilyName.HasValue;
            var fFamilyNames = spellFamilyName?.Value ?? 0;

            var bSpellAura = auraType.HasValue;
            var fSpellAura = auraType?.Value ?? 0;

            var bSpellEffect = spellEffect.HasValue;
            var fSpellEffect = spellEffect?.Value ?? 0;

            var bTarget1 = targetA.HasValue;
            var fTarget1 = targetA?.Value ?? 0;

            var bTarget2 = targetB.HasValue;
            var fTarget2 = targetB?.Value ?? 0;

            var spellEntryFilters = advancedSpellInfoFilters.Where(x => !x.IsEmpty)
                .Select(x => x.CreateFilter())
                .ToList();

            var spellList = await Task.Run(() =>
            {
                List<SpellViewModel> spellList = new List<SpellViewModel>();
                foreach (var spellViewModel in AllSpellsViewModel.Instance.Spells)
                {
                    var spell = DBC.DBC.Spell[spellViewModel.Entry];
                    bool isMatch = ((id == 0 || spell.ID == id) && (ic == 0 || spell.SpellIconID == ic) && (at == 0 ||
                                       (spell.Attributes & at) != 0 || (spell.AttributesEx & at) != 0 ||
                                       (spell.AttributesEx2 & at) != 0 ||
                                       (spell.AttributesEx3 & at) != 0 || (spell.AttributesEx4 & at) != 0 ||
                                       (spell.AttributesEx5 & at) != 0 ||
                                       (spell.AttributesEx6 & at) != 0 || (spell.AttributesEx7 & at) != 0)) &&
                                   ((id != 0 || ic != 0 && at != 0) || spell.SpellName.ContainsText(name)) &&
                                   (!bFamilyNames || spell.SpellFamilyName == (int)fFamilyNames) &&
                                   (!bSpellEffect || spell.Effect.ContainsElement((uint)fSpellEffect)) &&
                                   (!bSpellAura || spell.EffectApplyAuraName.ContainsElement((uint)fSpellAura)) &&
                                   (!bTarget1 || spell.EffectImplicitTargetA.ContainsElement((uint)fTarget1)) &&
                                   (!bTarget2 || spell.EffectImplicitTargetB.ContainsElement((uint)fTarget2));

                    if (!isMatch)
                        continue;

                    if (spellEntryFilters.Count > 0)
                    {
                        foreach (var filter in spellEntryFilters)
                        {
                            if (!filter(spell))
                            {
                                isMatch = false;
                                break;
                            }
                        }
                    }

                    if (!isMatch)
                        continue;

                    if (cancellationToken.IsCancellationRequested)
                        return spellList;

                    spellList.Add(spellViewModel);
                }

                return spellList;
            });

            if (cancellationToken.IsCancellationRequested)
                return;

            using var _ = Spells.SuspendNotifications();
            Spells.Clear();
            Spells.AddRange(spellList);
        }

        await FilterCore(token.Token);
        if (pendingSearch == token)
            pendingSearch = null;
    }
    
    private void FillStructFilterTypes<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(List<StructFilterTypeViewModel> output)
    {
        var type = typeof(T).GetMembers();
        var i = 0;
        foreach (var str in type)
        {
            if (!(str is FieldInfo) && !(str is PropertyInfo))
                continue;

            output.Add(new StructFilterTypeViewModel(str, $"({i:000}) {str.Name}"));
            ++i;
        }
    }
}

public class StructFilterTypeViewModel
{
    public StructFilterTypeViewModel(MemberInfo memberInfo, string name)
    {
        MemberInfo = memberInfo;
        Name = name;
    }

    public MemberInfo MemberInfo { get; set; }
    public string Name { get; set; }

    public override string ToString() => Name;
}