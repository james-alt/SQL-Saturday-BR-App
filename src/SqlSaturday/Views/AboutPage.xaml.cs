using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SqlSaturday.ViewModels;

namespace SqlSaturday.Views
{
    public partial class AboutPage 
        : ContentPage
    {
        private AboutViewModel viewModel;

        public AboutPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AboutViewModel();
        }
    }
}
