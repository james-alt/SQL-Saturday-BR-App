using System.Collections.ObjectModel;
using SqlSaturday.Core.Entities;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using SqlSaturday.Core.Interfaces;
using MvvmHelpers;

namespace SqlSaturday.ViewModels
{
    public class SpeakersViewModel
        : BaseViewModel
    {
        private IRepository<Speaker, string> repository =>
            DependencyService.Get<IRepository<Speaker, string>>();

        public ObservableCollection<Speaker> Speakers { get; set; }
        public Command LoadSpeakersCommand { get; private set; }

        public SpeakersViewModel()
        {
            Title = "Speakers";
            Speakers = new ObservableCollection<Speaker>();
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
                Speakers.Clear();
                var speakers = await repository.List();

                foreach(var speaker in speakers)
                {
                    Speakers.Add(speaker);
                }
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
