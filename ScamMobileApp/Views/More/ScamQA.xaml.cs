using ScamMobileApp.ViewModels.More;
using ScamMobileApp.Views.Questions;
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
    public partial class ScamQA : ContentPage
    {
        public ScamQA()
        {
            InitializeComponent();
            BindingContext = new HelpCenterViewModel(Navigation);

        }

        private void To_QAsection(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuestionsAndAnswer());
        }
    }
}