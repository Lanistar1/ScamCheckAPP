using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.ViewModels.ScamType;
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
    public partial class TypeOfScam : ContentPage
    {
        public TypeOfScam()
        {
            InitializeComponent();
            BindingContext = new scamtypeViewModel(Navigation);

        }

    }
}