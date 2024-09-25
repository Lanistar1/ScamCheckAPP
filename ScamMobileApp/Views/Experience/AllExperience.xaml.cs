using Rg.Plugins.Popup.Services;
using ScamMobileApp.Popup;
using ScamMobileApp.ViewModels.Experience;
using ScamMobileApp.ViewModels.ScamType;
using ScamMobileApp.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Experience
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllExperience : ContentPage
    {
        public AllExperience()
        {
            InitializeComponent();
            BindingContext = new GetExperienceViewModel(Navigation);

        }

        private void To_ShareExperience(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShareScamExperience());
        }

        //private void To_TakeActionPopup(object sender, EventArgs e)
        //{
        //    PopupNavigation.Instance.PushAsync(new TakeActionPopup(Navigation));
        //}
    }
}