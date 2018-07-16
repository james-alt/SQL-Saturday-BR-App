using SqlSaturday.Core.Entities;
using SqlSaturday.ViewModels;
using Xamarin.Forms;

namespace SqlSaturday.Views
{
    public partial class SpeakerPage : ContentPage
    {
        private SpeakerViewModel viewModel;

        public SpeakerPage(
            Speaker speaker)
        {
            InitializeComponent();

            BindingContext = viewModel = new SpeakerViewModel(speaker);
        }
    }
}
