using System.Diagnostics;
using MAUIClient.DataService;
using MAUIClient.Models;

namespace MauiClient.Pages;

[QueryProperty(nameof(ToDo),"ToDo")]

public partial class ManageToDoPage : ContentPage
{
    private IToDoService _toDoService;

    private ToDo _todo;
    private bool _isNew;

    public ToDo ToDo
    {
        get => _todo;
        set
        {
            _isNew = IsNew(value);
            _todo = value;
            OnPropertyChanged();
        }
    }
	public ManageToDoPage(IToDoService toDoService)
    {
       
		InitializeComponent();

        _toDoService = toDoService;

        BindingContext = this;
    }

    bool IsNew(ToDo toDo)
    {
        if (toDo.Id == 0)
            return true;
        return false;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            Debug.WriteLine(" -- Add New Item --- ");
            await _toDoService.AddToDoAsync(ToDo);
        }
        else
        {
            Debug.WriteLine(" -- Update Item --");
            await _toDoService.UpdateToDoAsync(ToDo);
        }

        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _toDoService.DeleteToDoAsync(ToDo.Id);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancleButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}