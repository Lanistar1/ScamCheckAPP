using ScamMobileApp.ViewModels.ScamCalculator;
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
    public partial class QRcodeThirdQuestion : ContentPage
    {
        public QRcodeThirdQuestion()
        {
            InitializeComponent();
            BindingContext = new QrcodeViewModel(Navigation);

        }

        private void To_forthQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QRcodeFourthQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}