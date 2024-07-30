using ScamMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{

    public class WarningTipsViewModel : BaseViewModel
    {
        //private INavigation Navigation;
        public ObservableCollection<Scam> Scams { get; set; }

        public WarningTipsViewModel(INavigation navigation)
        {
            Scams = new ObservableCollection<Scam>
            {
                new Scam { Title = "Unsolicited communication", FullDescription = "If someone contacts you out of the blue via phone, email, or social media, offering you an opportunity that seems too good to be true, it may be a scam." },
                new Scam { Title = "High-pressure tactics", FullDescription = "Scammers often use high-pressure tactics to make you act quickly without thinking through the consequences. For example, they may say that an offer is only available for a limited time or that you must act immediately to avoid missing out." },
                new Scam { Title = "Request for personal or financial information", FullDescription = "Scammers may ask for personal or financial information such as your social security number/ national ID number, credit card details, or bank account information. Be cautious when sharing this type of information, especially with people or companies that you don't know." },
                new Scam { Title = "Offers that seem too good to be true", FullDescription = "Scammers may ask for personal or financial information such as your social security number/ national ID number, credit card details, or bank account information. Be cautious when sharing this type of information, especially with people or companies that you don't know." },
                new Scam { Title = "Suspicious payment methods", FullDescription = "Scammers may ask for personal or financial information such as your social security number/ national ID number, credit card details, or bank account information. Be cautious when sharing this type of information, especially with people or companies that you don't know." },
                new Scam { Title = "Poor grammar and spelling", FullDescription = "Scammers may ask for personal or financial information such as your social security number/ national ID number, credit card details, or bank account information. Be cautious when sharing this type of information, especially with people or companies that you don't know." },
                new Scam { Title = "Fake websites and email addresses", FullDescription = "Scammers may ask for personal or financial information such as your social security number/ national ID number, credit card details, or bank account information. Be cautious when sharing this type of information, especially with people or companies that you don't know." },
                new Scam { Title = "Emotional appeals", FullDescription = "Scammers may ask for personal or financial information such as your social security number/ national ID number, credit card details, or bank account information. Be cautious when sharing this type of information, especially with people or companies that you don't know." }
            };
        }

        public ICommand ToggleDescriptionCommand => new Command<Scam>(ToggleDescription);

        //private void ToggleDescription(Scam scam)
        //{
        //    scam.IsExpanded = !scam.IsExpanded;
        //}

        private void ToggleDescription(Scam scam)
        {
            if (scam == null)
            {
                Debug.WriteLine("Scam parameter is null in ToggleDescription.");
                return;
            }

            try
            {
                scam.IsExpanded = !scam.IsExpanded;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in ToggleDescription: {ex.Message}");
            }
        }
    }

}
