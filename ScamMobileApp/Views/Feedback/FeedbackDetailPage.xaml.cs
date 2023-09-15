using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.Feedback;
using ScamMobileApp.ViewModels.Experience;
using ScamMobileApp.ViewModels.FeedBack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Feedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackDetailPage : ContentPage
    {
        public FeedbackDetailPage(ObservableCollection<GetFeedbackData> selectedItems)
        {
            InitializeComponent();
            BindingContext = new FeedbackDetailViewModel(Navigation, selectedItems);

        }
    }
}