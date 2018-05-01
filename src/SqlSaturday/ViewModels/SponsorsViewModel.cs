using System.Collections.ObjectModel;
using SqlSaturday.Core.Entities;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Linq;
using SqlSaturday.Core.Interfaces;

namespace SqlSaturday.ViewModels
{
    public class SponsorsViewModel
        : BaseViewModel
    {
        private IRepository<Sponsor, string> repository =>
            DependencyService.Get<IRepository<Sponsor, string>>();

        public ObservableCollection<Sponsor> Sponsors { get; set; }
        public Command LoadSponsorsCommand { get; private set; }

        public SponsorsViewModel()
        {
            Title = "Sponsors";
            Sponsors = new ObservableCollection<Sponsor>();

            LoadSponsorsCommand = new Command(
                async () => await ExecuteLoadSponsorsCommand());
        }

        private async Task ExecuteLoadSponsorsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Sponsors.Clear();
                var sponsors = await repository.List();

                foreach (var sponsor in sponsors)
                {
                    Sponsors.Add(sponsor);
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
