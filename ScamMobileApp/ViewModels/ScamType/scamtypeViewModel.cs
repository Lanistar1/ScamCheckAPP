using ScamMobileApp.Helpers;
using ScamMobileApp.Models;
using ScamMobileApp.Models.ScamType;
using ScamMobileApp.Views.Questions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.ScamType
{
    public class scamtypeViewModel : BaseViewModel
    {
        private ObservableCollection<Scam> scamType;
        public ObservableCollection<Scam> ScamType
        {
            get => scamType;
            set
            {
                scamType = value;
                OnPropertyChanged(nameof(ScamType));
            }
        }

        private ObservableCollection<Scam> realScamType;
        public ObservableCollection<Scam> RealScamType
        {
            get => realScamType;
            set
            {
                realScamType = value;
                OnPropertyChanged(nameof(RealScamType));
            }
        }

        private string emptyPlaceholder = "Fetching Customers...";
        public string EmptyPlaceholder
        {
            get => emptyPlaceholder;
            set
            {
                emptyPlaceholder = value;
                OnPropertyChanged(nameof(EmptyPlaceholder));
            }
        }


        private string searchEntry = string.Empty;
        private CancellationTokenSource searchDelayTokenSource;
        public string SearchEntry
        {
            get => searchEntry;
            set
            {
                searchEntry = value;

                // Cancel the previous search delay task if it exists
                searchDelayTokenSource?.Cancel();

                // Create a new cancellation token source
                searchDelayTokenSource = new CancellationTokenSource();

                // Delay the execution of the command to allow the value to update
                Task.Delay(TimeSpan.FromMilliseconds(200), searchDelayTokenSource.Token)
                    .ContinueWith(_ =>
                    {
                        if (!searchDelayTokenSource.Token.IsCancellationRequested)
                        {
                            SearchEntryTextChangedCommand.Execute(searchEntry);
                        }
                    });

                OnPropertyChanged(nameof(SearchEntry));
            }
        }

        public scamtypeViewModel(INavigation navigation)
        {
            Navigation = navigation;


            ScamType = new ObservableCollection<Scam>{
                new Scam { Title = "ATM SKIMMING SCAM", FullDescription = "ATM skimming scams involve criminals attaching devices to ATMs that can steal credit card information when the victim inserts heir card. Detecting ATM skimming scams involves being observant and cautious when using ATMs."},
                new Scam { Title = "BUSINESS EMAIL COMPROMISE(BEC) SCAMS", FullDescription = "BEC scams involve criminals posing as business executives or suppliers in order to trick employees into making wire transfers or other payments to fraudulent accounts."},
                new Scam { Title = "CHARITY SCAM",  FullDescription = "Charity scams involve fake charities that claim to be raising money for a good cause, but actually keep the money for themselves. Scammers often use urgency to prevent you from researching the charity's legitimacy. Legitimate charities won't pressure you to donate instantly."},
                new Scam { Title = "EMPLOYMENT OPPORTUNITY SCAMS",  FullDescription = "Employment scams involve fake job postings or offers that require people to pay for training or equipment, or provide personal information in order to get the job.These scams also involve fake job listings that require people to pay for background checks, training, or equipment, or that involve unrealistic promises of high-paying jobs."},
                new Scam { Title = "FAKE INVOICE SCAMS", FullDescription = "Fake invoice scams involve criminals posing as suppliers or vendors and sending fake invoices to businesses, tricking them into paying for products or services that were never provided."},
                new Scam { Title = "GIFT CARD SCAMS",  FullDescription = "A gift card scam is a fraudulent scheme in which scammers deceive individuals into purchasing gift cards and providing the scammers with the card information or codes. Once the scammers obtain the gift card information, they can quickly redeem the funds or sell the cards on the black market, making it difficult to trace or recover the money."},
                new Scam { Title = "GRANDPARENT OR PARENT SCAM",  FullDescription = "These scams involve being cautious when receiving urgent calls or text messages from individuals claiming to be family members in distress."},
                new Scam { Title = "IDENTITY THEFT SCAM", FullDescription = "This is when someone steals your personal information, such as your name, date of birth, and social security number/ national ID number in order to open accounts or make purchases in your name."},
                new Scam { Title = "IMPERSONATION SCAM", FullDescription = "Impersonation scams, also known as impersonation fraud or social engineering scams, occur when an individual or group pretends to be someone else, such as a trusted authority figure or a legitimate organization, with the intention of deceiving others for personal gain. The scammer typically adopts a false identity or uses stolen personal information to manipulate victims into providing sensitive information, money, or access to their accounts or systems."},
                new Scam { Title = "INVESTMENT SCAM",  FullDescription ="Investment scams refer to fraudulent schemes or activities designed to deceive individuals or entities into making investments in fake or non-existent opportunities, often with the promise of high returns.  Investment scams can have devastating financial consequences for victims who lose their savings or assets."},
                new Scam { Title = "LOTTERY, PRIZE OR FREE GIFTS SCAM", FullDescription = "These scams involve convincing people that they have won a prize in a sweepstakes or lottery, but require them to pay a fee or provide personal information in order to claim the prize"},
                new Scam { Title = "ONLINE SHOPPING SCAMS", FullDescription = "This is when you purchase goods online, but the seller doesn't actually send you the product or sends you a counterfeit or defective product."},
                new Scam { Title = "PHISHING SCAM (email)", FullDescription = "Phishing scams are malicious attempts by cybercriminals. In essence, phishing is a crafty act of deception, where cybercriminals masquerade as trusted entities through seemingly legitimate emails, messages, or websites. Their ultimate goal? To trick unsuspecting victims into revealing sensitive personal information, financial details, credit card details or login credentials."},
                new Scam { Title = "QR CODE SCAMS", FullDescription = "QR codes are two-dimensional barcodes that can be easily scanned using a smartphone's camera. They are often used to quickly access websites, apps, or other content without typing in URLs or searching.  "},
                new Scam { Title = "RANSOMWARE  SCAM", FullDescription = "A ransomware scam is a type of computer attack where cybercriminals use a special program to lock up a person's computer files. Ransomware is typically spread through deceptive emails, malicious downloads, or vulnerabilities in software. Cybercriminals demand ransom money from their victims in exchange for releasing the data."},
                new Scam { Title = "ROMANCE SCAM", FullDescription = "Romance scams involve creating fake profiles on dating websites or social media platforms in order to establish a romantic relationship with someone and then trick them into sending money.  The scam typically escalates quickly where the scammer acts as if they have fallen for the victim as this creates a sense of attachment on the victim's part so that the victim feels guilty refusing the scammer's requests which usually involves money."},
                new Scam { Title = "SMISHING SCAM (text messages SMS)   ", FullDescription = "This type of scam involves text messages (SMS). The victim receives a text message that appears to be from a legitimate source, such as a bank or other financial institution, government agency, or well-known company. The message may contain a link or phone number that the victim is prompted to click or call, and they are then directed to a website or automated phone system that asks for personal information, such as login credentials or credit card information."},
                new Scam { Title = "SOCIAL MEDIA SCAM", FullDescription = "Social media scams involve fake social media accounts or messages that try to trick people into giving away personal information or money. Look for the following criteria in a profile or message, which will help you determine whether it is legitimate or not."},
                new Scam { Title = "TAX SCAM", FullDescription = "A tax scam is a fraudulent scheme designed to deceive individuals or businesses into providing sensitive personal, financial, or tax-related information or making payments to scammers who pretend to represent a legitimate tax authority. Tax scams typically aim to exploit people's fears and concerns related to taxes, often using tactics of urgency, threats, or promises of large refunds. To protect yourself from tax scams, it's important to be cautious when receiving unsolicited communications related to taxes, verify the legitimacy of any requests for information or payments, and only provide personal or financial information to trusted sources. If you suspect you've encountered a tax scam, report it to your country's tax agency and law enforcement.\r\n"},
                new Scam { Title = "TECH SUPPORT SCAM", FullDescription = "These scams involve fake tech support calls or messages that claim to offer help with computer or software problems, but actually aim to trick people into paying for unnecessary services or downloading malware."},
                new Scam { Title = "VISHING SCAM (Phone calls or voice messages) ", FullDescription = "A combination of “voice” and “phishing” is called “vishing”. Vishing scams involve criminals using phone calls to trick people into giving away personal information or money. This is a type of telephone scam where the caller (the scammer) makes unsolicited calls to potential victims and tries to deceive them into providing personal information or transferring money. The scammer might claim to be a representative of a legitimate company, such as a bank, a utility company, or a government agency, or they might offer a product or service that seems too good to be true and/or use scare tactics or other high-pressure tactics to get the victim to act quickly."},


             };

            RealScamType = ScamType;

        }

        public ICommand ToggleDescriptionCommand => new Command<Scam>(ToggleDescription);

        private void ToggleDescription(Scam scam)
        {
            scam.IsExpanded = !scam.IsExpanded;
        }



        public Command SearchEntryTextChangedCommand => new Command<string>((searchEntry) => SearchBar_TextChanged(searchEntry));
        public Command SearchCommand { get; }


        // Search implementation
        private void SearchBar_TextChanged(string _searchEntry)
        {
            try
            {
                if (_searchEntry.Length >= 1 && RealScamType.Count() >= 1)
                {
                    var _newList = ScamType.Where(x => x.Title.Contains(_searchEntry, StringComparison.OrdinalIgnoreCase));
                    if (_newList.Count() <= 0)
                    {
                        RealScamType = new ObservableCollection<Scam>(_newList);
                        EmptyPlaceholder = "No Scam type found";
                    }
                    else if (_newList.Count() > 0)
                    {
                        RealScamType = new ObservableCollection<Scam>(_newList);
                    }
                    else
                    {
                        RealScamType = new ObservableCollection<Scam>(ScamType);
                    }

                }
                else if (ScamType != null)
                {
                    RealScamType = null;
                    RealScamType = new ObservableCollection<Scam>(ScamType);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
