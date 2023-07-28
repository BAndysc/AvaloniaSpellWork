using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged.SourceGenerator;
using SpellWork.Filtering;

namespace SpellWork.ViewModels;

public abstract partial class AdvancedFilterViewModel : ObservableObject
{
    public List<StructFilterTypeViewModel> Types { get; }
    public List<EnumViewModel<CompareType>> CompareTypes { get; }
    [Notify] private StructFilterTypeViewModel? type;
    [Notify] private EnumViewModel<CompareType>? comparison;
    [Notify] private string? value = "";

    public AdvancedFilterViewModel(List<StructFilterTypeViewModel> types, List<EnumViewModel<CompareType>> compareTypes)
    {
        Types = types;
        CompareTypes = compareTypes;
        
        type = Types.Count > 0 ? Types[0] : null;
        comparison = CompareTypes.Count > 0 ? CompareTypes[0] : null;
    }
}

public partial class AdvancedFilterViewModel<T> : AdvancedFilterViewModel
{
    public Func<T, bool> CreateFilter()
    {
        if (Type is null ||
            string.IsNullOrWhiteSpace(Value) ||
            Comparison is null)
            return _ => true;
        
        return FilterFactory.CreateFilterFunc<T>(Type.MemberInfo, Value, Comparison.Value.Value);   
    }

    public AdvancedFilterViewModel(List<StructFilterTypeViewModel> types, 
        List<EnumViewModel<CompareType>> compareTypes) : base(types, compareTypes)
    {
    }

    public bool IsEmpty => Type is null || string.IsNullOrWhiteSpace(Value) || Comparison is null;
}