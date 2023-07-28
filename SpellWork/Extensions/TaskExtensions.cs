namespace SpellWork.Extensions;

public static class TaskExtensions
{
    public static void ListenErrors(this Task task)
    {
        task.ContinueWith(t =>
        {
            Globals.MessageBoxService.Show("Error in async task", t.Exception!.Message);
            Console.WriteLine(t.Exception);
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
}