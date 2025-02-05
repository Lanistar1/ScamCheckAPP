using ScamMobileApp.ViewModels.More;
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
    public partial class TriviaQuestionPage : ContentPage
    {
        public TriviaQuestionViewModel ViewModel { get; set; }

        public TriviaQuestionPage()
        {
            InitializeComponent();
            //BindingContext = new TriviaQuestionViewModel(Navigation);
            ViewModel = new TriviaQuestionViewModel(Navigation);
            BindingContext = ViewModel;

        }

        private void OnOptionSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                string selectedOption = e.SelectedItem.ToString();
                ViewModel.OnOptionSelected(selectedOption);
                ((ListView)sender).SelectedItem = null; // Deselect item
            }
        }
    }
}