using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MvvmHelpers;
using SqlSaturday.Core.Entities;
using SqlSaturday.Core.Interfaces;
using Xamarin.Forms;

namespace SqlSaturday.ViewModels
{
    public class SessionsViewModel
        : BaseViewModel
    {
        private IRepository<Session, string> repository =
            DependencyService.Get<IRepository<Session, string>>();

        public ObservableRangeCollection<Grouping<string, Session>> GroupedSessions { get; set; }

        public Command LoadSessionsCommand { get; private set; }

        public SessionsViewModel()
        {
            Title = "Sessions";
            GroupedSessions = new ObservableRangeCollection<Grouping<string, Session>>();

            LoadSessionsCommand = new Command(
                async () => await ExecuteLoadSessionsCommand());
        }

        private async Task ExecuteLoadSessionsCommand()
        {
            if(IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                GroupedSessions.Clear();

                var sessions = await repository.List();

                var sorted = from session in sessions
                             orderby session.SessionStartTime
                             group session by session.DisplayTime into sessionGroup
                             select new Grouping<string, Session>(sessionGroup.Key, sessionGroup);

                GroupedSessions.AddRange(sorted);
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
