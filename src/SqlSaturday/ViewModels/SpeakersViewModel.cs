using SqlSaturday.Core.Entities;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Linq;
using SqlSaturday.Core.Interfaces;
using MvvmHelpers;

namespace SqlSaturday.ViewModels
{
    public class SpeakersViewModel
        : BaseViewModel
    {
        private IRepository<Speaker, string> repository =>
            DependencyService.Get<IRepository<Speaker, string>>();

		public ObservableRangeCollection<Grouping<string, Speaker>> GroupedSpeakers { get; set; }
        public Command LoadSpeakersCommand { get; private set; }

        public SpeakersViewModel()
        {
            Title = "Speakers";

			GroupedSpeakers = new ObservableRangeCollection<Grouping<string, Speaker>>();

            LoadSpeakersCommand = new Command(
                async () => await ExecuteLoadSpeakersCommand());
        }

        private async Task ExecuteLoadSpeakersCommand()
        {
            if(IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                GroupedSpeakers.Clear();
                var speakers = await repository.List();

				var sorted = from speaker in speakers
							 orderby speaker.LastName
							 group speaker by speaker.NameKey into speakerGroup
							 select new Grouping<string, Speaker>(speakerGroup.Key, speakerGroup);

				GroupedSpeakers.AddRange(sorted);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
