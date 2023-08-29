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
    public partial class ScamLink : ContentPage
    {
        public ScamLink()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void To_usa(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.scamspotter.org/?gclid=CjwKCAjwloynBhBbEiwAGY25dNVSMF-2A5Hon-XMthSsI-B1nlL0BPLeosDsliv3zP-O45psHfvbLRoCI9UQAvD_"));

        }

        [Obsolete]
        private void To_uk(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.ageuk.org.uk/information-advice/work-learning/technology-internet/internet-security/?gclid=Cj0KCQjwuZGnBhD1ARIsACxbAVj2jWdJHVcZD4uu2qHTm6bzX-HW5twIk3Jz0ouMkb0wUh2DNZjv6csaAma_EALw_wcB"));

        }

        [Obsolete]
        private void To_canada(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.canada.ca/en/revenue-agency/campaigns/fraud-scams.html"));

        }
    }
}