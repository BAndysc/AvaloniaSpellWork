using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged.SourceGenerator;

namespace SpellWork.ViewModels;

public partial class LoadingViewModel : ObservableObject, ITaskProgress
{
    public ObservableCollection<LoadingTaskViewModel> Tasks { get; } = new ObservableCollection<LoadingTaskViewModel>();

    public LoadingViewModel()
    {
    }

    public async Task LoadTask()
    {
        var loader = new Loader();
        await loader.AsyncDataLoad(this);
    }

    private class SubTaskProgress : ISubTaskProgress
    {
        private readonly LoadingTaskViewModel _viewModel;

        public SubTaskProgress(LoadingTaskViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Report(string status)
        {
            if (SynchronizationContext.Current is null)
                _viewModel.Status = status;
            else
            {
                SynchronizationContext.Current.Post(_ =>
                {
                    _viewModel.Status = status;
                }, null);                
            }
        }
    }

    public ISubTaskProgress CreateSubTask(string name)
    {
        var viewModel = new LoadingTaskViewModel(name);
        Tasks.Add(viewModel);
        return new SubTaskProgress(viewModel);
    }
}

public partial class LoadingTaskViewModel : ObservableObject
{
    [Notify] private string status = "";
    
    public LoadingTaskViewModel(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

public interface ITaskProgress
{
    ISubTaskProgress CreateSubTask(string name);
}

public interface ISubTaskProgress
{
    void Report(string status);    
}

public class EmptyTaskProgress : ITaskProgress
{
    private class SubTaskProgress : ISubTaskProgress
    {
        public void Report(string status)
        {
        
        }
    }

    public ISubTaskProgress CreateSubTask(string name)
    {
        return new SubTaskProgress();
    }
}