using Xamarin.Forms;
using SqlSaturday.Views;

namespace SqlSaturday
{
    public class MainPage 
        : TabbedPage
    {
        private Page homePage;
        private Page sessionsPage;
        private Page speakersPage;
        private Page sponsorsPage;
        private Page aboutPage;

        public MainPage()
        {            
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    InitializeIos();
                    break;
                default:
                    InitializeDefault();
                    break;
            }

            Children.Add(homePage);
            Children.Add(sessionsPage);
            Children.Add(speakersPage);
            Children.Add(sponsorsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        private void InitializeIos()
        {
            homePage = new NavigationPage(new HomePage())
            {
                Title = "Home"
            };

            sessionsPage = new NavigationPage(new SessionsPage())
            {
                Title = "Sessions"
            };

            speakersPage = new NavigationPage(new SpeakersPage())
            {
                Title = "Speakers"
            };

            sponsorsPage = new NavigationPage(new SponsorsPage())
            {
                Title = "Sponsors"
            };

            aboutPage = new NavigationPage(new AboutPage())
            {
                Title = "About"
            };

            homePage.Icon = "tab_feed.png";
            sessionsPage.Icon = "tab_feed.png";
            speakersPage.Icon = "tab_feed.png";
            sponsorsPage.Icon = "tab_feed.png";
            aboutPage.Icon = "tab_feed.png";
        }

        private void InitializeDefault()
        {
            homePage = new HomePage
            {
                Title = "Home"
            };

            sessionsPage = new SessionsPage
            {
                Title = "Sessions"
            };

            speakersPage = new SpeakersPage
            {
                Title = "Speakers"
            };

            sponsorsPage = new SponsorsPage
            {
                Title = "Sponsors"
            };
            aboutPage = new AboutPage
            {
                Title = "About"
            };
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
