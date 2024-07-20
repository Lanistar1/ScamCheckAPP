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

        private string title6;
        public string Title6
        {
            get => title6;
            set
            {
                title6 = value;
                OnPropertyChanged(nameof(Title6));
            }
        }


        private string title7;
        public string Title7
        {
            get => title7;
            set
            {
                title7 = value;
                OnPropertyChanged(nameof(Title7));
            }
        }


        public HelpCenterViewModel(INavigation navigation)
        {
            Navigation = navigation;

            ShowDetailCommand = new Command(async () => await ShowDetailCommandExecute());
            ShowNoDetailCommand = new Command(async () => await ShowNoDetailCommandExecute());

            ScamQA = "ScamQ&A";

            Title = "Start ScamQ&A";

            Title1 = "Don't let scammers take advantage of you! Stay one step ahead with ScamQ&A.";
            Title2 = "The ScamQ&A check feature can help you assess the likelihood of a scam, especially when encountering suspicious activities involving AI-driven deception. If you have doubts about a suspicious activity, simply";
            Title3 = "1. Open the ScamQ&A page.";
            Title4 = "2. Choose the relevant category.";
            Title5 = "3. Answer four yes/no questions.";
            Title6 = "4  Receive a score indicating the likelihood of a scam.";
            Title7 = "Your scam result will provide a clear indication of the likelihood of a scam, allowing you to make smart decisions before proceeding further.  ScamQ&A also provides valuable tips and recommendations to help you navigate through potentially situations. Avoid scams, protect your finances, and make informed decisions with ease. ";
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
