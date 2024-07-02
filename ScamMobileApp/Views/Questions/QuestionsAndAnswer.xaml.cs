using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.ViewModels.ScamCalculator;
using ScamMobileApp.Views.More;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionsAndAnswer : ContentPage
    {
        public QuestionsAndAnswer()
        {
            InitializeComponent();
            BindingContext = new ScamQuestionAndAnswerViewModel(Navigation);


        }

        private void To_LearningCentre(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LearningCentre());
        }
    }
}