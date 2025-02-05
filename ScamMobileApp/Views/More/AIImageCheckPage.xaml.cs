using ScamMobileApp.Models.Others;
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
    public partial class AIImageCheckPage : ContentPage
    {
        public AIImageCheckPage()
        {
            InitializeComponent();
            BindingContext = new AIimageCheckViewModel(Navigation);

        }
    }
}