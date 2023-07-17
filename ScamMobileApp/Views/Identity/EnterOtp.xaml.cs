using ScamMobileApp.ViewModels.Identity;
using ScamMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Identity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterOtp : ContentPage
    {
        ResetPasswordViewModel pageViewModel = null;

        public EnterOtp()
        {
            pageViewModel = new ResetPasswordViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;
        }
    }
}