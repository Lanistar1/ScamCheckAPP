using ScamMobileApp.Models.Experience;
using ScamMobileApp.ViewModels.Experience;
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
    public partial class ReportPostPage : ContentPage
    {
        public ReportPostPage(ObservableCollection<ExperienceData> selectedItems)
        {
            InitializeComponent();
            BindingContext = new ExperienceDetailViewModel(Navigation, selectedItems);

        }
    }
}