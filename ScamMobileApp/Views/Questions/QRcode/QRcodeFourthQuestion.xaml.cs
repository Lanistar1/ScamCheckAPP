﻿using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions.QRcode
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRcodeFourthQuestion : ContentPage
    {
        public QRcodeFourthQuestion()
        {
            InitializeComponent();
            BindingContext = new QrcodeViewModel(Navigation);

        }
        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}