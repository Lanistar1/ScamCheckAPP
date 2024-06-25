using ScamMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Others
{
    public class scamQAdescriptionViewmodel : BaseViewModel
    {
        private string scamQAzzyy;
        public string ScamQAzzyy
        {
            get => scamQAzzyy;
            set
            {
                scamQAzzyy = value;
                OnPropertyChanged(nameof(ScamQAzzyy));
            }
        }

        private string disclaimer;
        public string Disclaimer
        {
            get => disclaimer;
            set
            {
                disclaimer = value;
                OnPropertyChanged(nameof(Disclaimer));
            }
        }


        private string buttonText;
        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }


        private string descriptionscamzz;
        public string Descriptionscamzz
        {
            get => descriptionscamzz;
            set
            {
                descriptionscamzz = value;
                OnPropertyChanged(nameof(Descriptionscamzz));
            }
        }

        public scamQAdescriptionViewmodel(INavigation navigation)
        {
            Navigation = navigation;

            ScamQAzzyy = "ScamQ&A";

            ButtonText = "Start ScamQ&A";

            Disclaimer = "ScamQ&A values your privacy and security. We do not collect any personally identifiable information from you, ensuring your data remains confidential. All answers and results are stored securely on your device, giving you full control over your information ";

            Descriptionscamzz = "Don’t let scammers take advantage of you! Stay one step ahead with ScamQ&A, the essential mobile app designed to help you make informed decisions and protect yourself from fraud. When faced with a suspicious offer, a questionable message, or a potential scam scenario, open the app and answer four tailored questions based on the situation and let ScamQ&A provide you with a scam assessment. Empower yourself with ScamQ&A’s easy-to-understand results. Your scam result will provide a clear indication of the likelihood of a scam, allowing you to make smart decisions before proceeding further. ScamQ&A also provides valuable tips and recommendations to help you navigate through potentially to avoid scams, protect your finances and make informed decisions with ease. ScamQ&A is your trusted companion in the fight against scammers.";
        }

       
    }

}
