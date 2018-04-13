using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SqlSaturday.ViewModels;

namespace SqlSaturday.Views
{
    public partial class SpeakersPage 
        : ContentPage
    {
        private SpeakersViewModel speakersViewModel;

        public SpeakersPage()
        {
            InitializeComponent();

            BindingContext = speakersViewModel = new SpeakersViewModel();
        }
    }
}
