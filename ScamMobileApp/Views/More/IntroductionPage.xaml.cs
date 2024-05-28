using ScamMobileApp.ViewModels.Identity;
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
        ScamViewModel pageViewModel = null;

        public IntroductionPage ()
		{
            //pageViewModel = new ScamViewModel();
            InitializeComponent();
            //BindingContext = pageViewModel;
        }
	}
}