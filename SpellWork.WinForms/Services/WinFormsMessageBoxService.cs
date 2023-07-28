namespace SpellWork.Services;

public class WinFormsMessageBoxService : IMessageBoxService
{
    public Task Show(string title, string message)
    {
        MessageBox.Show(message, title);
        return Task.CompletedTask;
    }
}