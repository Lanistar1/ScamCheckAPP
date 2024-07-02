using ScamMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{

    public class PreventiveTipsViewModel : BaseViewModel
    {
        private INavigation Navigation;

        public ObservableCollection<Scam> Scams { get; set; }

        public PreventiveTipsViewModel(INavigation navigation)
        {
            Scams = new ObservableCollection<Scam>
            {
                new Scam { Title = "Protect personal information", FullDescription = "Never give out personal information, such as your social security number, bank account numbers, or credit card information, to anyone who contacts you unsolicited. Be cautious when giving out personal information online, especially on social media and other public forums." },
                new Scam { Title = "Be wary of unsolicited offers", FullDescription = "Be suspicious of any offers that come to you out of the blue, especially those that require you to act quickly or pay money upfront. Remember, if it sounds too good to be true, it probably is." },
                new Scam { Title = "Verify before you trust", FullDescription = "Verify the identity and credentials of anyone who contacts you and claims to be a representative of a company or organization. Check with the company or organization directly to confirm their claims." },
                new Scam { Title = "Stay Informed", FullDescription = "Stay up-to-date on the latest scams and frauds, and be aware of the warning signs. This will help you recognize suspicious activity and avoid falling victim to scams." },
                new Scam { Title = "Secure your devices", FullDescription = "Keep your devices and accounts secure by using strong passwords and two-factor authentication, and keeping your software and antivirus programs up-to-date." },
                new Scam { Title = "Check your accounts regularly", FullDescription = "Regularly review your bank and credit card statements to look for any unauthorized charges or withdrawals. If you see anything suspicious, report it immediately." },
                new Scam { Title = "Use reputable sources", FullDescription = "Use reputable sources for information, such as government websites or established news outlets. Be wary of information that comes from unknown or unverified sources." },
                new Scam { Title = "Use ScamQ&A", FullDescription = "if/when you have any doubts or should you just need to do a sanity check when you are unsure of a situation." }
            };
        }

        public ICommand ToggleDescriptionCommand => new Command<Scam>(ToggleDescription);

        private void ToggleDescription(Scam scam)
        {
            scam.IsExpanded = !scam.IsExpanded;
        }
    }

}
