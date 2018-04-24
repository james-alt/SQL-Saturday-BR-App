using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SqlSaturday.ViewModels;

namespace SqlSaturday.Views
{
    public partial class SponsorsPage 
        : ContentPage
    {
        private SponsorsViewModel viewModel;

        public SponsorsPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = viewModel = new SponsorsViewModel();
        }
    }
}
