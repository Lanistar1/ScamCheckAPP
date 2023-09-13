using ScamMobileApp.ViewModels.Identity;
using ScamMobileApp.ViewModels;
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
    public partial class ProfilePage : ContentPage
    {
        GetProfileViewModel pageViewModel = null;

        public ProfilePage()
        {
            pageViewModel = new GetProfileViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;
        }
    }
}