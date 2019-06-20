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

            sessionsListView.ItemSelected += 
                SessionsListViewItemSelected;
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            sessionsListView.ItemSelected -=
                SessionsListViewItemSelected;
        }

        private async void SessionsListViewItemSelected(
            object sender, 
            SelectedItemChangedEventArgs e)
        {
            var session = sessionsListView.SelectedItem as Session;
            if (session == null)
                return;

            var sessionPage = new SessionPage(session);
            await Navigation.PushAsync(
                sessionPage);

            sessionsListView.SelectedItem = null;
        }

    }
}
