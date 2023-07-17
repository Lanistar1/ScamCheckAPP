using ScamMobileApp.ViewModels.Identity;
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
    public partial class Login : ContentPage
    {
        LoginViewModel pageViewModel = null;

        public Login()
        {
            pageViewModel = new LoginViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;
        }


        private void To_ForgotPassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgetPassword());
        }

        private void To_Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private void To_Tabbed(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Tabbed());
        }
    }
}