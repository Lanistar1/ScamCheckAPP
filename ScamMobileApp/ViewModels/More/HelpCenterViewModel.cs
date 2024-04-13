using ScamMobileApp.Models.Home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{
    public class HelpCenterViewModel : BaseViewModel
    {
        private INavigation Navigation;

        private bool deatilNotVisible = true;
        public bool DeatilNotVisible
        {
            get => deatilNotVisible;
            set
            {
                deatilNotVisible = value;
                OnPropertyChanged(nameof(DeatilNotVisible));
            }
        }

        private bool deatilVisible = false;
        public bool DeatilVisible
        {
            get => deatilVisible;
            set
            {
                deatilVisible = value;
                OnPropertyChanged(nameof(DeatilVisible));
            }
        }

        private string scamQA;
        public string ScamQA
        {
            get => scamQA;
            set
            {
                scamQA = value;
                OnPropertyChanged(nameof(ScamQA));
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string title1;
        public string Title1
        {
            get => title1;
            set
            {
                title1 = value;
                OnPropertyChanged(nameof(Title1));
            }
        }

        private string title2;
        public string Title2
        {
            get => title2;
            set
            {
                title2 = value;
                OnPropertyChanged(nameof(Title2));
            }
        }

        private string title3;
        public string Title3
        {
            get => title3;
            set
            {
                title3 = value;
                OnPropertyChanged(nameof(Title3));
            }
        }

        private string title4;
        public string Title4
        {
            get => title4;
            set
            {
                title4 = value;
                OnPropertyChanged(nameof(Title4));
            }
        }

        private string title5;
        public string Title5
        {
            get => title5;
            set
            {
                title5 = value;
                OnPropertyChanged(nameof(Title5));
            }
        }

        public HelpCenterViewModel(INavigation navigation)
        {
            Navigation = navigation;

            ShowDetailCommand = new Command(async () => await ShowDetailCommandExecute());
            ShowNoDetailCommand = new Command(async () => await ShowNoDetailCommandExecute());

            ScamQA = "ScamQ&A";

            Title = "Start ScamQ&A";

            Title1 = "Don't let scammers take advantage of you! Stay one step ahead with ScamQ&A, the essential mobile app designed to help you make informed decisions and protect yourself from fraud.";
            Title2 = "When faced with a suspicious offer, a questionable message, or a potential scam scenario, open the app and answer four tailored questions based on the situation and let ScamQ&A provide you with a scam assessment.";
            Title3 = "Empower yourself with ScamQ&A's easy-to-understand results. Your scam result will provide a clear indication of the likelihood of a scam, allowing you to make smart decisions before proceeding further. ScamQ&A also provides valuable tips and recommendations to help you navigate through potentially.";
            Title4 = "Avoid scams, protect your finances, and make informed decisions with ease. ScamQ&A is your trusted companion in the fight against scammers.";
            Title5 = "ScamQ&A values your privacy and security. We do not collect any personally identifiable information from you, ensuring your data remains confidential. All answers and results are stored securely on your device, giving you full control over your information.";

        }

        public ICommand ShowDetailCommand { get; }

        private async Task ShowDetailCommandExecute()
        {
            try
            {
                DeatilNotVisible = true;
                DeatilVisible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public ICommand ShowNoDetailCommand { get; }

        private async Task ShowNoDetailCommandExecute()
        {
            try
            {
                DeatilNotVisible = false;
                DeatilVisible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
