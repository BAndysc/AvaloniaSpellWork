using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
using SpellWork.Services;

namespace SpellWork.Avalonia.Services;

public class MessageBoxService : IMessageBoxService
{
    private record Dialog(string title, string message);

    private bool useWindows = true;
    private Visual? topLevel;
    private List<(Dialog dialog, TaskCompletionSource tcs)> pendingDialogs = new();
    
    private async Task ShowDialog(Dialog dialog)
    {
        var taskDialog = new TaskDialog();
        taskDialog.XamlRoot = topLevel;
        taskDialog.Header = dialog.title;
        taskDialog.Content = dialog.message;
        taskDialog.Buttons = new List<TaskDialogButton>()
        {
            new TaskDialogButton("Ok", null)
        };
        await taskDialog.ShowAsync(!useWindows);            
    }

    public async Task Show(string title, string message)
    {
        var dialog = new Dialog(title, message);
        if (topLevel == null)
        {
            TaskCompletionSource tcs = new TaskCompletionSource();
            pendingDialogs.Add((dialog, tcs));
            await tcs.Task;
        }
        else
        {
            await ShowDialog(dialog);
        }
    }

    public void InitializeTopLevel(Visual visual)
    {
        useWindows = visual is WindowBase;
        topLevel = visual;
        ShowPendingWindows().ContinueWith(x => Console.WriteLine(x.Exception), TaskContinuationOptions.OnlyOnFaulted);
    }

    private async Task ShowPendingWindows()
    {
        var copy = pendingDialogs.ToList();
        pendingDialogs.Clear();
        foreach (var (dialog, tcs) in copy)
        {
            await ShowDialog(dialog);
            tcs.SetResult();
        }
    }
}