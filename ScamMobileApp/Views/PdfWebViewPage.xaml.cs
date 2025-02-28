﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfWebViewPage : ContentPage
    {
        public PdfWebViewPage(string url)
        {
            InitializeComponent();
            webView.Source = new UrlWebViewSource { Url = url };

        }
    }
}