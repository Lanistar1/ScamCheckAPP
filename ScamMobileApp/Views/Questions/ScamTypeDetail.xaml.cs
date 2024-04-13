using ScamMobileApp.Models.Experience;
using ScamMobileApp.Models.ScamType;
using ScamMobileApp.ViewModels.Experience;
using ScamMobileApp.ViewModels.ScamType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Questions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScamTypeDetail : ContentPage
    {
        public ScamTypeDetail(ObservableCollection<ScamTypeData> selectedItems)
        {
            InitializeComponent();
            BindingContext = new ScamtypeDetailViewModel(Navigation, selectedItems);
        }
    }
}