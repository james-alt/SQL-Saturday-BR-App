using SqlSaturday.Core.Entities;
using MvvmHelpers;

namespace SqlSaturday.ViewModels
{
    public class SessionViewModel
        : BaseViewModel
    {
        public SessionViewModel(
            Session session)
        {            
            Session = session;

            Title = "Session";
        }

        public Session Session { get; }
    }
}
