using Xamarin.Forms;
using SqlSaturday.ViewModels;
using SqlSaturday.Core.Entities;

namespace SqlSaturday.Views
{
    public partial class SessionsPage 
        : ContentPage
    {
        private SessionsViewModel viewModel;

        public SessionsPage(Track track)
        {
            InitializeComponent();

            BindingContext = viewModel = new SessionsViewModel(
                track);
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

            if(viewModel.GroupedSessions.Count == 0)
            {
                viewModel.LoadSessionsCommand.Execute(null);
            }
		}
	}
}
