using System;

using Xamarin.Forms;
using SqlSaturday.Infrastructure.Mock.Repositories;

namespace SqlSaturday
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterDependencies();

            if (Device.RuntimePlatform == Device.iOS)
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        private void RegisterDependencies()
        {
            DependencyService.Register<SpeakerRepository>();
        }
    }
}
