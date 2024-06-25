using ScamMobileApp.ViewModels.Identity;
using ScamMobileApp.ViewModels.More;
using ScamMobileApp.ViewModels.Others;
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
	public partial class IntroductionPage : ContentPage
	{
        public IntroductionPage ()
		{
            InitializeComponent();
            BindingContext = new LearningCentreViewModel(Navigation);

        }
    }
}