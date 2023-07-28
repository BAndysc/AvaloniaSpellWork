using SpellWork.ViewModels;

namespace SpellWork;

public class Loader
{
    public async Task AsyncDataLoad(ITaskProgress progress)
    {
        try
        {
            await DBC.DBC.Load(progress);
        }
        catch (Exception e)
        {
            await Globals.MessageBoxService.Show("Error during data loading", e.Message);
        }
    }
}