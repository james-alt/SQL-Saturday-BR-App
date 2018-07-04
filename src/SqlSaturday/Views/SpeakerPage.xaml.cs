using SqlSaturday.Core.Entities;
using SqlSaturday.ViewModels;
using Xamarin.Forms;

namespace SqlSaturday.Views
{
    public partial class SpeakerPage : ContentPage
    {
        private SpeakerViewModel viewModel;

        public SpeakerPage()
        {
            var speaker = new Speaker
            {
                Name = "James Alt",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sed mattis mauris, at luctus lectus. Nunc nec tortor magna. In egestas ipsum in diam ultrices sagittis. Cras euismod volutpat risus in pretium. Nunc sodales nulla nec enim feugiat, sed scelerisque elit cursus. Aliquam facilisis vitae massa ac venenatis. Vestibulum rhoncus tortor ac viverra vehicula. Mauris sed suscipit nisi. Quisque blandit sapien vitae ante luctus rhoncus. Ut ut turpis mi.",
                Id = "0"
            };

            BindingContext = viewModel = new SpeakerViewModel(speaker);
        }

        public SpeakerPage(
            Speaker speaker)
        {
            InitializeComponent();

            BindingContext = viewModel = new SpeakerViewModel(speaker);
        }
    }
}
