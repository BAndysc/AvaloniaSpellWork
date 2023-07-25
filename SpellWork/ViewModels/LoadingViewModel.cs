using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged.SourceGenerator;

namespace SpellWork.ViewModels;

public partial class LoadingViewModel : ObservableObject, ITaskProgress
{
    [Notify] private string loadingText = "Loading SpellWork...";

    public LoadingViewModel()
    {
    }

    public async Task LoadTask()
    {
        var loader = new Loader();
        await loader.AsyncDataLoad(this);
    }

    public void Report(string status)
    {
        LoadingText = "Loading " + status + ".dbc...";
    }
}

public interface ITaskProgress
{
    void Report(string status);
}