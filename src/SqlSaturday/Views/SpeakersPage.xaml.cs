using Xamarin.Forms;
using SqlSaturday.ViewModels;
using SqlSaturday.Core.Entities;

namespace SqlSaturday.Views
{
    public partial class SpeakersPage 
        : ContentPage
    {
        private SpeakersViewModel viewModel;

        public SpeakersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SpeakersViewModel();
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

            if(viewModel.GroupedSpeakers.Count == 0)
            {
                viewModel.LoadSpeakersCommand.Execute(null);
            }

            speakersListView.ItemSelected +=
                SpeakersListViewItemSelected;
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            speakersListView.ItemSelected -= 
                SpeakersListViewItemSelected;
        }

        private async void SpeakersListViewItemSelected(
            object sender, 
            SelectedItemChangedEventArgs e)
        {
            var speaker = speakersListView.SelectedItem as Speaker;
            if (speaker == null)
                return;

            var speakerPage = new SpeakerPage(speaker);
            await Navigation.PushAsync(speakerPage);

            speakersListView.SelectedItem = null;
        }

	}
}
