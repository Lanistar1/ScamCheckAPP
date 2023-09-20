using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Home;
using ScamMobileApp.Models.ScamType;
using ScamMobileApp.Popup;
using ScamMobileApp.Views.Experience;
using ScamMobileApp.Views.More;
using ScamMobileApp.Views.Questions;
using ScamMobileApp.Views.Questions.ATM;
using ScamMobileApp.Views.Questions.Business;
using ScamMobileApp.Views.Questions.Charity;
using ScamMobileApp.Views.Questions.Employment;
using ScamMobileApp.Views.Questions.Fake;
using ScamMobileApp.Views.Questions.Giftcard;
using ScamMobileApp.Views.Questions.Grandparent;
using ScamMobileApp.Views.Questions.Identity;
using ScamMobileApp.Views.Questions.Impersonation;
using ScamMobileApp.Views.Questions.Investment;
using ScamMobileApp.Views.Questions.Lottery;
using ScamMobileApp.Views.Questions.Online;
using ScamMobileApp.Views.Questions.Phishing;
using ScamMobileApp.Views.Questions.QRcode;
using ScamMobileApp.Views.Questions.Ransomware;
using ScamMobileApp.Views.Questions.Romance;
using ScamMobileApp.Views.Questions.Smishing;
using ScamMobileApp.Views.Questions.SocialMedia;
using ScamMobileApp.Views.Questions.Tax;
using ScamMobileApp.Views.Questions.Tech;
using ScamMobileApp.Views.Questions.Vishing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.ScamType
{
    public class scamtypeViewModel : BaseViewModel
    {
        private ObservableCollection<ScamTypeData> scamType;
        public ObservableCollection<ScamTypeData> ScamType
        {
            get => scamType;
            set
            {
                scamType = value;
                OnPropertyChanged(nameof(ScamType));
            }
        }

        private ObservableCollection<ScamTypeData> realScamType;
        public ObservableCollection<ScamTypeData> RealScamType
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

        //private string searchEntry = string.Empty;
        //public string SearchEntry
        //{
        //    get => searchEntry;
        //    set
        //    {
        //        searchEntry = value;
        //        if (!string.IsNullOrEmpty(searchEntry))
        //        {
        //            SearchEntryTextChangedCommand.Execute(searchEntry);
        //        };

        //        //SearchEntryTextChangedCommand.Execute(searchEntry);

        //        OnPropertyChanged(nameof(SearchEntry));
        //    }
        //}

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

        public ObservableCollection<ScamTypeData> selectedItems;
        public ObservableCollection<ScamTypeData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        public scamtypeViewModel(INavigation navigation)
        {
            Navigation = navigation;


            ScamType = new ObservableCollection<ScamTypeData>{
                new ScamTypeData { ScamType = "PHISHING SCAM (email)", DishImage = "scamarrow.png", ScamDetail = "Phishing scams are malicious attempts by cybercriminals. In essence, phishing is a crafty act of deception, where cybercriminals masquerade as trusted entities through seemingly legitimate emails, messages, or websites. Their ultimate goal? To trick unsuspecting victims into revealing sensitive personal information, financial details, credit card details or login credentials."},
                new ScamTypeData { ScamType = "VISHING SCAM (Phone calls or voice messages) ", DishImage = "scamarrow.png", ScamDetail = "A combination of “voice” and “phishing” is called “vishing”. Vishing scams involve criminals using phone calls to trick people into giving away personal information or money. This is a type of telephone scam where the caller (the scammer) makes unsolicited calls to potential victims and tries to deceive them into providing personal information or transferring money. The scammer might claim to be a representative of a legitimate company, such as a bank, a utility company, or a government agency, or they might offer a product or service that seems too good to be true and/or use scare tactics or other high-pressure tactics to get the victim to act quickly."},
                new ScamTypeData { ScamType = "SMISHING SCAM (text messages SMS)   ", DishImage = "scamarrow.png", ScamDetail = "This type of scam involves text messages (SMS). The victim receives a text message that appears to be from a legitimate source, such as a bank or other financial institution, government agency, or well-known company. The message may contain a link or phone number that the victim is prompted to click or call, and they are then directed to a website or automated phone system that asks for personal information, such as login credentials or credit card information."},
                new ScamTypeData { ScamType = "INVESTMENT SCAM", DishImage = "scamarrow.png", ScamDetail ="Investment scams refer to fraudulent schemes or activities designed to deceive individuals or entities into making investments in fake or non-existent opportunities, often with the promise of high returns.  Investment scams can have devastating financial consequences for victims who lose their savings or assets."},
                new ScamTypeData { ScamType = "ROMANCE SCAM", DishImage = "scamarrow.png", ScamDetail = "Romance scams involve creating fake profiles on dating websites or social media platforms in order to establish a romantic relationship with someone and then trick them into sending money.  The scam typically escalates quickly where the scammer acts as if they have fallen for the victim as this creates a sense of attachment on the victim's part so that the victim feels guilty refusing the scammer's requests which usually involves money."},
                new ScamTypeData { ScamType = "QR CODE SCAMS", DishImage = "scamarrow.png", ScamDetail = "QR codes are two-dimensional barcodes that can be easily scanned using a smartphone's camera. They are often used to quickly access websites, apps, or other content without typing in URLs or searching.  "},
                new ScamTypeData { ScamType = "IMPERSONATION SCAM", DishImage = "scamarrow.png", ScamDetail = "Impersonation scams, also known as impersonation fraud or social engineering scams, occur when an individual or group pretends to be someone else, such as a trusted authority figure or a legitimate organization, with the intention of deceiving others for personal gain. The scammer typically adopts a false identity or uses stolen personal information to manipulate victims into providing sensitive information, money, or access to their accounts or systems."},
                new ScamTypeData { ScamType = "RANSOMWARE  SCAM", DishImage = "scamarrow.png", ScamDetail = "A ransomware scam is a type of computer attack where cybercriminals use a special program to lock up a person's computer files. Ransomware is typically spread through deceptive emails, malicious downloads, or vulnerabilities in software. Cybercriminals demand ransom money from their victims in exchange for releasing the data."},
                new ScamTypeData { ScamType = "ATM SKIMMING SCAM", DishImage = "scamarrow.png", ScamDetail = "ATM skimming scams involve criminals attaching devices to ATMs that can steal credit card information when the victim inserts heir card. Detecting ATM skimming scams involves being observant and cautious when using ATMs."},
                new ScamTypeData { ScamType = "TECH SUPPORT SCAM", DishImage = "scamarrow.png", ScamDetail = "These scams involve fake tech support calls or messages that claim to offer help with computer or software problems, but actually aim to trick people into paying for unnecessary services or downloading malware."},
                new ScamTypeData { ScamType = "BUSINESS EMAIL COMPROMISE(BEC) SCAMS", DishImage = "scamarrow.png", ScamDetail = "BEC scams involve criminals posing as business executives or suppliers in order to trick employees into making wire transfers or other payments to fraudulent accounts."},
                new ScamTypeData { ScamType = "LOTTERY, PRIZE OR FREE GIFTS SCAM", DishImage = "scamarrow.png", ScamDetail = "These scams involve convincing people that they have won a prize in a sweepstakes or lottery, but require them to pay a fee or provide personal information in order to claim the prize"},
                new ScamTypeData { ScamType = "SOCIAL MEDIA SCAM", DishImage = "scamarrow.png", ScamDetail = "Social media scams involve fake social media accounts or messages that try to trick people into giving away personal information or money. Look for the following criteria in a profile or message, which will help you determine whether it is legitimate or not."},
                new ScamTypeData { ScamType = "TAX SCAM", DishImage = "scamarrow.png", ScamDetail = "A tax scam is a fraudulent scheme designed to deceive individuals or businesses into providing sensitive personal, financial, or tax-related information or making payments to scammers who pretend to represent a legitimate tax authority. Tax scams typically aim to exploit people's fears and concerns related to taxes, often using tactics of urgency, threats, or promises of large refunds. To protect yourself from tax scams, it's important to be cautious when receiving unsolicited communications related to taxes, verify the legitimacy of any requests for information or payments, and only provide personal or financial information to trusted sources. If you suspect you've encountered a tax scam, report it to your country's tax agency and law enforcement.\r\n"},
                new ScamTypeData { ScamType = "IDENTITY THEFT SCAM", DishImage = "scamarrow.png", ScamDetail = "This is when someone steals your personal information, such as your name, date of birth, and social security number/ national ID number in order to open accounts or make purchases in your name."},
                new ScamTypeData { ScamType = "GRANDPARENT OR PARENT SCAM", DishImage = "scamarrow.png", ScamDetail = "These scams involve being cautious when receiving urgent calls or text messages from individuals claiming to be family members in distress."},
                new ScamTypeData { ScamType = "CHARITY SCAM", DishImage = "scamarrow.png", ScamDetail = "Charity scams involve fake charities that claim to be raising money for a good cause, but actually keep the money for themselves. Scammers often use urgency to prevent you from researching the charity's legitimacy. Legitimate charities won't pressure you to donate instantly."},
                new ScamTypeData { ScamType = "ONLINE SHOPPING SCAMS", DishImage = "scamarrow.png", ScamDetail = "This is when you purchase goods online, but the seller doesn't actually send you the product or sends you a counterfeit or defective product."},
                new ScamTypeData { ScamType = "EMPLOYMENT OPPORTUNITY SCAMS", DishImage = "scamarrow.png", ScamDetail = "Employment scams involve fake job postings or offers that require people to pay for training or equipment, or provide personal information in order to get the job.These scams also involve fake job listings that require people to pay for background checks, training, or equipment, or that involve unrealistic promises of high-paying jobs."},
                new ScamTypeData { ScamType = "FAKE INVOICE SCAMS", DishImage = "scamarrow.png", ScamDetail = "Fake invoice scams involve criminals posing as suppliers or vendors and sending fake invoices to businesses, tricking them into paying for products or services that were never provided."},
                new ScamTypeData { ScamType = "GIFT CARD SCAMS", DishImage = "scamarrow.png", ScamDetail = "A gift card scam is a fraudulent scheme in which scammers deceive individuals into purchasing gift cards and providing the scammers with the card information or codes. Once the scammers obtain the gift card information, they can quickly redeem the funds or sell the cards on the black market, making it difficult to trace or recover the money."},

             };

            RealScamType = ScamType;

            TappedCommand = new Command<ScamTypeData>(async (model) => await TappedCommandExecute(model));

        }

        


        public Command SearchEntryTextChangedCommand => new Command<string>((searchEntry) => SearchBar_TextChanged(searchEntry));
        public Command SearchCommand { get; }
        public Command TappedCommand { get; }



        private async Task TappedCommandExecute(ScamTypeData model)
        {

            try
            {
                var mod = model;

                model.isSelected = model.isSelected ? false : true;
                if (SelectedItems.Count > 0)
                {
                    SelectedItems.Clear();
                }
                SelectedItems.Add(model);

                await Navigation.PushAsync(new ScamTypeDetail(SelectedItems), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }




            //try
            //{
            //    await LoadingPopup.Instance.Show("Loading...");

            //    var mod = model;

            //    model.isSelected = model.isSelected ? false : true;
            //    if (model.ScamType.Contains("PHISHING"))
            //    {
            //        await Navigation.PushAsync(new PhishingFirstQuestion());
            //    }
            //    else if(model.ScamType.Contains("VISHING"))
            //    {
            //        await Navigation.PushAsync(new VishingFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("SMIShING"))
            //    {
            //        await Navigation.PushAsync(new SmishingFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("INVESTMENT"))
            //    {
            //        await Navigation.PushAsync(new InvestmentFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("ROMANCE"))
            //    {
            //        await Navigation.PushAsync(new RomanceFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("QR CODE"))
            //    {
            //        await Navigation.PushAsync(new QRcodeFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("IMPERSONATION"))
            //    {
            //        await Navigation.PushAsync(new ImpersonationFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("RANSOMWARE"))
            //    {
            //        await Navigation.PushAsync(new RansomewareFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("ATM SKIMMING"))
            //    {
            //        await Navigation.PushAsync(new ATMFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("TECH SUPPORT"))
            //    {
            //        await Navigation.PushAsync(new TechFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("BUSINESS EMAIL"))
            //    {
            //        await Navigation.PushAsync(new BusinessFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("LOTTERY"))
            //    {
            //        await Navigation.PushAsync(new LotteryFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("SOCIAL MEDIA"))
            //    {
            //        await Navigation.PushAsync(new SocialMediaFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("TAX"))
            //    {
            //        await Navigation.PushAsync(new TaxFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("IDENTITY"))
            //    {
            //        await Navigation.PushAsync(new IdentityfirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("GRANDPARENT"))
            //    {
            //        await Navigation.PushAsync(new GrandParentFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("CHARITY"))
            //    {
            //        await Navigation.PushAsync(new CharityFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("ONLINE SHOPPING"))
            //    {
            //        await Navigation.PushAsync(new OnlineShoppingFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("EMPLOYMENT"))
            //    {
            //        await Navigation.PushAsync(new EmploymentFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("FAKE INVOICE"))
            //    {
            //        await Navigation.PushAsync(new FakeFirstQuestion());
            //    }
            //    else if (model.ScamType.Contains("GIFT CARD"))
            //    {
            //        await Navigation.PushAsync(new GiftCardFirstQuestion());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //finally
            //{
            //    await LoadingPopup.Instance.Hide();
            //}
        }

        private void SearchBar_TextChanged(string _searchEntry)
        {
            try
            {
                if (_searchEntry.Length >= 1 && RealScamType.Count() >= 1)
                {
                    var _newList = ScamType.Where(x => x.ScamType.Contains(_searchEntry, StringComparison.OrdinalIgnoreCase));
                    if (_newList.Count() <= 0)
                    {
                        RealScamType = new ObservableCollection<ScamTypeData>(_newList);
                        EmptyPlaceholder = "No Scam type found";
                    }
                    else if (_newList.Count() > 0)
                    {
                        RealScamType = new ObservableCollection<ScamTypeData>(_newList);
                    }
                    else
                    {
                        RealScamType = new ObservableCollection<ScamTypeData>(ScamType);
                    }

                }
                else if (ScamType != null)
                {
                    RealScamType = null;
                    RealScamType = new ObservableCollection<ScamTypeData>(ScamType);
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
