using System.Collections.ObjectModel;
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
    public class SponsorsViewModel
        : BaseViewModel
    {
        private IRepository<Sponsor, string> repository =>
            DependencyService.Get<IRepository<Sponsor, string>>();

        public ObservableRangeCollection<Grouping<string, Sponsor>> GroupedSponsors { get; set; }
        public Command LoadSponsorsCommand { get; private set; }

        public SponsorsViewModel()
        {
            Title = "Sponsors";
            GroupedSponsors = new ObservableRangeCollection<Grouping<string, Sponsor>>();

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
                GroupedSponsors.Clear();
                var sponsors = await repository.List();

                var sorted = from sponsor in sponsors
                             orderby sponsor.SponsorLevel.Id, sponsor.Name
                             group sponsor by sponsor.SponsorLevel.Label into sponsorGroup
                             select new Grouping<string, Sponsor>(sponsorGroup.Key, sponsorGroup);

                GroupedSponsors.AddRange(sorted);
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
