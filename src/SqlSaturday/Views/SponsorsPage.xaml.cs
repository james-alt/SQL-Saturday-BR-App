﻿using System;
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

            BindingContext = viewModel = new SponsorsViewModel();
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

            if(viewModel.Sponsors.Count == 0)
            {
                viewModel.LoadSponsorsCommand.Execute(null);
            }
		}
	}
}
