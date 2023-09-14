using ScamMobileApp.ViewModels.FeedBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Feedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllFeedbackPage : ContentPage
    {
        public AllFeedbackPage()
        {
            InitializeComponent();
            BindingContext = new GetFeedbackViewModel(Navigation);

        }
    }
}