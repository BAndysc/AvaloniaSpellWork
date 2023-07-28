namespace SpellWork.Services;

public interface IMessageBoxService
{
    Task Show(string title, string message);
}