using SpellWork.ViewModels;

namespace SpellWork;

public class Loader
{
    public async Task AsyncDataLoad(ITaskProgress progress)
    {
        try
        {
            var subtask = progress.CreateSubTask("Loading");
            await DBC.DBC.Load(state => subtask.Report($"{state}%"));
        }
        catch (Exception e)
        {
            await Globals.MessageBoxService.Show("Error during data loading", e.Message);
        }
    }
}