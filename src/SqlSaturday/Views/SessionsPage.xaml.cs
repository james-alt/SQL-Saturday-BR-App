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

		protected override void OnAppearing()
		{
			base.OnAppearing();

            if(viewModel.Sessions.Count == 0)
            {
                viewModel.LoadSessionsCommand.Execute(null);
            }
		}
	}
}
