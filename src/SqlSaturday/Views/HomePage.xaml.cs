using Xamarin.Forms;
using SqlSaturday.ViewModels;

namespace SqlSaturday.Views
{
    public partial class HomePage 
        : ContentPage
    {
        private HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = viewModel = new HomeViewModel();
        }
    }
}
