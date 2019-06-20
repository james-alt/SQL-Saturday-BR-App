using SqlSaturday.Core.Entities;
using SqlSaturday.ViewModels;
using Xamarin.Forms;

namespace SqlSaturday.Views
{
    public partial class SessionPage 
        : ContentPage
    {
        private SessionViewModel viewModel;

        public SessionPage(
            Session session)
        {
            InitializeComponent();

            BindingContext = viewModel = new SessionViewModel(session);
        }
    }
}
