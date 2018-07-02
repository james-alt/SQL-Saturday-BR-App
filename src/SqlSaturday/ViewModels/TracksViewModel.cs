using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmHelpers;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;
using Xamarin.Forms;
using SqlSaturday.Infrastructure.Xml.Repositories;

namespace SqlSaturday.ViewModels
{
    public class TracksViewModel
        : BaseViewModel
    {
        private IRepository<Track, string> repository =
            DependencyService.Get<IRepository<Track, string>>();
        
        public ObservableRangeCollection<Track> Tracks { get; set; }
        public Command LoadTracksCommand { get; set; }

        public TracksViewModel()
        {
            Title = "Sessions";

            repository = new TracksRepository();
            Tracks = new ObservableRangeCollection<Track>();

            LoadTracksCommand = new Command(
                async () => await ExecuteLoadTracksCommand());
        }

        private async Task ExecuteLoadTracksCommand()
        {
            if(IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Tracks.Clear();

                var tracks = await repository
                    .List();

                Tracks.AddRange(tracks);
            }
            catch(Exception ex)
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