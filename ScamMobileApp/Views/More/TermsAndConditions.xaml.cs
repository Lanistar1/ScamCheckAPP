using ScamMobileApp.ViewModels.More;
using ScamMobileApp.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.More
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsAndConditions : ContentPage
    {
        public TermsAndConditions()
        {
            InitializeComponent();
            BindingContext = new TermsViewModel(Navigation);

        }
    }
}