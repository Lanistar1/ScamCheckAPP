using ScamMobileApp.Helpers;
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
    public partial class Register : ContentPage
    {
        private DateTime DateType { get; set; }

        SignupViewModel pageViewModel = null;

        public Register()
        {
            pageViewModel = new SignupViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;
        }


        private void To_Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private void Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private void DatePicker_SelectedDateChanged(object sender, DateChangedEventArgs e)
        {
            DatePicker picker = sender as DatePicker;

            DateType = picker.Date;

            Console.WriteLine(DateType);

            Global.DateType = DateType;
        }
    }
}