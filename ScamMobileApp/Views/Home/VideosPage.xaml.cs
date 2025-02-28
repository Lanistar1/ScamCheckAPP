﻿using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.ViewModels.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideosPage : ContentPage
    {
        public VideosPage()
        {
            InitializeComponent();
            BindingContext = new VideoListViewModel(Navigation);

        }
    }
}