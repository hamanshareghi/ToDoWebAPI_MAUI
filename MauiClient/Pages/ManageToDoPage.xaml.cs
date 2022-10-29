using MAUIClient.DataService;
using MAUIClient.Models;

namespace MauiClient.Pages;

public partial class ManageToDoPage : ContentPage
{
    private IToDoService _toDoService;

    private ToDo _todo;
    private bool _isNew;
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
}