using System.Diagnostics;
using MAUIClient.DataService;
using Microsoft.Maui.Controls;

namespace MauiClient
{
    public partial class MainPage : ContentPage
    {
        private IToDoService _toDoService;
        public MainPage(IToDoService toDoService)
        {
            _toDoService = toDoService;   
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await _toDoService.GetAllAsync();
        }

        async void OnAddToDoClicked(object sender, EventArgs e)
        {
            Debug.WriteLine(" -- Add button Clicked --- ");
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine(" -- Item Change Clicked  --- ");
        }

    }
}