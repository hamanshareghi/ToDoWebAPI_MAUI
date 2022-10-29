using MauiClient.Pages;

namespace MauiClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ManageToDoPage),typeof(ManageToDoPage));
        }
    }
}