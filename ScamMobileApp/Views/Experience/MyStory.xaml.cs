using ScamMobileApp.ViewModels.Experience;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.More;
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
	public partial class MyStory : ContentPage
	{
        PostExperienceViewModel pageViewModel = null;

        public MyStory ()
		{
            pageViewModel = new PostExperienceViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;
        }

        private void To_ShareStory(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShareScamExperience());
        }

        private void To_ViewStories(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllExperience());
        }
    }
}