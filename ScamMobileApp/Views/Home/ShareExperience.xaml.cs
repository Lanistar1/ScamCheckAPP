using ScamMobileApp.ViewModels.Experience;
using ScamMobileApp.Views.Experience;
using ScamMobileApp.Views.More;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShareExperience : ContentPage
    {
        PostExperienceViewModel pageViewModel = null;

        public ShareExperience()
        {
            pageViewModel = new PostExperienceViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;
        }

        private void To_Terms(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TermsAndConditions());
        }

        private void To_ViewStories(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllExperience());
        }
    }
}