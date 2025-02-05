using ScamMobileApp.Models.Others;
using ScamMobileApp.ViewModels.More;
using ScamMobileApp.ViewModels.Others;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.More
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TriviaQuestionDetailPage : ContentPage
    {
        public TriviaQuestionDetailPage(ObservableCollection<TriviaQuestionModel> selectedItems)
        {
            InitializeComponent();
            BindingContext = new TriviaQuestionDetailsViewModel(Navigation, selectedItems);

        }
    }
}