﻿using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.Romance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RomanceThirdQuestion : ContentPage
    {
        public RomanceThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new RomanceViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RomanceFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}