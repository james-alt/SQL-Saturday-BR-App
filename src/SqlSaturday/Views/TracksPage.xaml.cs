using SqlSaturday.Core.Entities;
using SqlSaturday.ViewModels;
using Xamarin.Forms;

namespace SqlSaturday.Views
{
    public partial class TracksPage 
        : ContentPage
    {
        private TracksViewModel viewModel;

        public TracksPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TracksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(viewModel.Tracks.Count == 0)
            {
                viewModel.LoadTracksCommand.Execute(null);
            }

            tracksListView.ItemSelected += 
                TracksListViewItemSelected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            tracksListView.ItemSelected -=
                TracksListViewItemSelected;
        }

        private async void TracksListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var track = tracksListView.SelectedItem as Track;
            if (track == null)
                return;

            var sessionsPage = new SessionsPage(track);
            await Navigation.PushAsync(sessionsPage);

            tracksListView.SelectedItem = null;
        }

    }
}
