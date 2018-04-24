using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SqlSaturday.ViewModels;

namespace SqlSaturday.Views
{
    public partial class SessionsPage 
        : ContentPage
    {
        private SessionsViewModel viewModel;

        public SessionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SessionsViewModel();
        }
    }
}
