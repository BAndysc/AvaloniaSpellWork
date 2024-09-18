using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData.Binding;
using PropertyChanged.SourceGenerator;
using SpellWork.DBC;
using SpellWork.DBC.Structures;
using SpellWork.Extensions;
using SpellWork.Filtering;
using SpellWork.Services;
using SpellWork.Spell;

namespace SpellWork.ViewModels;

public partial class SpellInfoViewModel : ObservableObject
{
    public List<StructFilterTypeViewModel> SpellFilterTypes { get; set; } = new();
    public List<StructFilterTypeViewModel> SpellEffectFilterTypes { get; set; } = new();

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
    
    private List<AdvancedFilterViewModel<SpellInfo>> advancedSpellInfoFilters = new();
    private List<AdvancedFilterViewModel<SpellEffectInfo>> advancedSpellEffectFilters = new();
    
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
        FillStructFilterTypes<SpellInfo>(SpellFilterTypes);
        FillStructFilterTypes<SpellEffectInfo>(SpellEffectFilterTypes);
        
        SpellFamilyNames = Enum.GetValues<SpellFamilyNames>().Select(EnumViewModel<SpellFamilyNames>.Create).ToList();
        AuraTypes = Enum.GetValues<AuraType>().Select(EnumViewModel<AuraType>.Create).ToList();
        SpellEffects = Enum.GetValues<SpellEffects>().Select(EnumViewModel<SpellEffects>.Create).ToList();
        Targets = Enum.GetValues<Targets>().Select(EnumViewModel<Targets>.Create).ToList();
        CompareTypes = Enum.GetValues<CompareType>().Select(EnumViewModel<CompareType>.CreateNoNumber).ToList();

        for (int i = 0; i < 2; ++i)
        {
            var filter = new AdvancedFilterViewModel<SpellInfo>(SpellFilterTypes, CompareTypes);
            advancedSpellInfoFilters.Add(filter);
            AdvancedFilters.Add(filter);
            filter.PropertyChanged += (_, _) => FilterAndSearch();
        }
        
        for (int i = 0; i < 2; ++i)
        {
            var filter = new AdvancedFilterViewModel<SpellEffectInfo>(SpellEffectFilterTypes, CompareTypes);
            advancedSpellEffectFilters.Add(filter);
            AdvancedFilters.Add(filter);
            filter.PropertyChanged += (_, _) => FilterAndSearch();
        }

        this.WhenValueChanged(x => x.SelectedSpell, false)
            .Subscribe(spell =>
            {
                if (spell != null && textView != null)
                {
                    Globals.Navigation.NavigateTo(spell.SpellName, $"?spell={spell.Entry}");
                    DBC.DBC.SpellInfoStore[(int)spell.Entry].Write(textView);
                }
            });

        this.WhenAnyPropertyChanged(nameof(SpellFamilyName),
            nameof(AuraType),
            nameof(SpellEffect),
            nameof(TargetA),
            nameof(TargetB)).Subscribe(_ => FilterAndSearch().ListenErrors());
        
        DoSearchCommand = new RelayCommand(() => FilterAndSearch().ListenErrors());
        SelectAllTextCommand = new RelayCommand(() => TextView?.SelectAll());
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

            var spellFilters = advancedSpellInfoFilters.Where(x => !x.IsEmpty)
                .Select(x => x.CreateFilter())
                .ToList();
                
            var spellEffectFilters = advancedSpellEffectFilters.Where(x => !x.IsEmpty)
                .Select(x => x.CreateFilter())
                .ToList();

            var spellList = await Task.Run(() =>
            {
                List<SpellViewModel> spellList = new List<SpellViewModel>();
                foreach (var spellViewModel in AllSpellsViewModel.Instance.Spells)
                {
                    var spellInfo = DBC.DBC.SpellInfoStore[(int)spellViewModel.Entry];
                    bool isMatch = ((id == 0 || spellInfo.ID == id) && (ic == 0 || spellInfo.SpellIconFileDataID == ic) &&
                                    (at == 0 || (spellInfo.Attributes & at) != 0 || (spellInfo.AttributesEx & at) != 0 ||
                                     (spellInfo.AttributesEx2 & at) != 0 || (spellInfo.AttributesEx3 & at) != 0 ||
                                     (spellInfo.AttributesEx4 & at) != 0 || (spellInfo.AttributesEx5 & at) != 0 ||
                                     (spellInfo.AttributesEx6 & at) != 0 || (spellInfo.AttributesEx7 & at) != 0 ||
                                     (spellInfo.AttributesEx8 & at) != 0 || (spellInfo.AttributesEx9 & at) != 0 ||
                                     (spellInfo.AttributesEx10 & at) != 0 || (spellInfo.AttributesEx11 & at) != 0 ||
                                     (spellInfo.AttributesEx12 & at) != 0 || (spellInfo.AttributesEx13 & at) != 0 ||
                                     (spellInfo.AttributesEx14 & at) != 0)) && ((id != 0 || ic != 0 && at != 0) ||
                                                                            spellInfo.Name.ContainsText(name))
                                    &&
                                    (!bFamilyNames || spellInfo.SpellFamilyName == (uint)fFamilyNames) &&
                                    (!bSpellEffect || spellInfo.HasEffect((SpellEffects)fSpellEffect)) &&
                                    (!bSpellAura || spellInfo.HasAura((AuraType)fSpellAura)) &&
                                    (!bTarget1 || spellInfo.HasTargetA((Targets)fTarget1)) &&
                                    (!bTarget2 || spellInfo.HasTargetB((Targets)fTarget2));
                    
                    if (!isMatch)
                        continue;

                    if (spellFilters.Count > 0)
                    {
                        foreach (var filter in spellFilters)
                        {
                            if (!filter(spellInfo))
                            {
                                isMatch = false;
                                break;
                            }
                        }
                    }
                    
                    if (spellEffectFilters.Count > 0)
                    {
                        bool anyEffectMatch = false;
                        foreach (var effect in spellInfo.SpellEffectInfoStore)
                        {
                            bool effectMatched = true;
                            foreach (var filter in spellEffectFilters)
                            {
                                if (!filter(effect))
                                {
                                    effectMatched = false;
                                    break;
                                }
                            }
                            anyEffectMatch |= effectMatched;
                        }
                        isMatch &= anyEffectMatch;
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

            if (str.GetCustomAttribute<IgnoreAutopopulatedFilterValueAttribute>() != null)
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