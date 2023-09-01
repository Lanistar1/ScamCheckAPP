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
    public partial class QRcodeSecondQuestion : ContentPage
    {
        public QRcodeSecondQuestion()
        {
            InitializeComponent();
            BindingContext = new QrcodeViewModel(Navigation);

        }

        private void To_thirdQuestion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QRcodeThirdQuestion());
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}