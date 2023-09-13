using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Home;
using ScamMobileApp.Models.ScamType;
using ScamMobileApp.Popup;
using ScamMobileApp.Views.More;
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

        public List<ScamTypeData> selectedItems;
        public List<ScamTypeData> SelectedItems
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
                new ScamTypeData { ScamType = "PHISHING SCAM (email)", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "VISHING SCAM (Phone calls or voice messages) ", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "SMIShING SCAM (text messages SMS)   ", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "INVESTMENT SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "ROMANCE SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "QR CODE SCAMS", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "IMPERSONATION SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "RANSOMWARE  SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "ATM SKIMMING SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "TECH SUPPORT SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "BUSINESS EMAIL COMPROMISE(BEC) SCAMS", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "LOTTERY, PRIZE OR FREE GIFTS SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "SOCIAL MEDIA SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "TAX SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "IDENTITY THEFT SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "GRANDPARENT OR PARENT SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "CHARITY SCAM", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "ONLINE SHOPPING SCAMS", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "EMPLOYMENT OPPORTUNITY SCAMS", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "FAKE INVOICE SCAMS", DishImage = "scamarrow.png"},
                new ScamTypeData { ScamType = "GIFT CARD SCAMS", DishImage = "scamarrow.png"},

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
                await LoadingPopup.Instance.Show("Loading...");

                var mod = model;

                model.isSelected = model.isSelected ? false : true;
                if (model.ScamType.Contains("PHISHING"))
                {
                    await Navigation.PushAsync(new PhishingFirstQuestion());
                }
                else if(model.ScamType.Contains("VISHING"))
                {
                    await Navigation.PushAsync(new VishingFirstQuestion());
                }
                else if (model.ScamType.Contains("SMIShING"))
                {
                    await Navigation.PushAsync(new SmishingFirstQuestion());
                }
                else if (model.ScamType.Contains("INVESTMENT"))
                {
                    await Navigation.PushAsync(new InvestmentFirstQuestion());
                }
                else if (model.ScamType.Contains("ROMANCE"))
                {
                    await Navigation.PushAsync(new RomanceFirstQuestion());
                }
                else if (model.ScamType.Contains("QR CODE"))
                {
                    await Navigation.PushAsync(new QRcodeFirstQuestion());
                }
                else if (model.ScamType.Contains("IMPERSONATION"))
                {
                    await Navigation.PushAsync(new ImpersonationFirstQuestion());
                }
                else if (model.ScamType.Contains("RANSOMWARE"))
                {
                    await Navigation.PushAsync(new RansomewareFirstQuestion());
                }
                else if (model.ScamType.Contains("ATM SKIMMING"))
                {
                    await Navigation.PushAsync(new ATMFirstQuestion());
                }
                else if (model.ScamType.Contains("TECH SUPPORT"))
                {
                    await Navigation.PushAsync(new TechFirstQuestion());
                }
                else if (model.ScamType.Contains("BUSINESS EMAIL"))
                {
                    await Navigation.PushAsync(new BusinessFirstQuestion());
                }
                else if (model.ScamType.Contains("LOTTERY"))
                {
                    await Navigation.PushAsync(new LotteryFirstQuestion());
                }
                else if (model.ScamType.Contains("SOCIAL MEDIA"))
                {
                    await Navigation.PushAsync(new SocialMediaFirstQuestion());
                }
                else if (model.ScamType.Contains("TAX"))
                {
                    await Navigation.PushAsync(new TaxFirstQuestion());
                }
                else if (model.ScamType.Contains("IDENTITY"))
                {
                    await Navigation.PushAsync(new IdentityfirstQuestion());
                }
                else if (model.ScamType.Contains("GRANDPARENT"))
                {
                    await Navigation.PushAsync(new GrandParentFirstQuestion());
                }
                else if (model.ScamType.Contains("CHARITY"))
                {
                    await Navigation.PushAsync(new CharityFirstQuestion());
                }
                else if (model.ScamType.Contains("ONLINE SHOPPING"))
                {
                    await Navigation.PushAsync(new OnlineShoppingFirstQuestion());
                }
                else if (model.ScamType.Contains("EMPLOYMENT"))
                {
                    await Navigation.PushAsync(new EmploymentFirstQuestion());
                }
                else if (model.ScamType.Contains("FAKE INVOICE"))
                {
                    await Navigation.PushAsync(new FakeFirstQuestion());
                }
                else if (model.ScamType.Contains("GIFT CARD"))
                {
                    await Navigation.PushAsync(new GiftCardFirstQuestion());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
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
