using Xamarin.Forms;
using SqlSaturday.ViewModels;

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
		}
	}
}
