using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public ObservableCollection<Session> Sessions { get; set; }
        public Command LoadSessionsCommand { get; private set; }

        public SessionsViewModel()
        {
            Title = "Sessions";
            Sessions = new ObservableCollection<Session>();
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
                Sessions.Clear();

                var sessions = await repository.List();

                foreach(var session in sessions)
                {
                    Sessions.Add(session);
                }
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
