using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Home;
using ScamMobileApp.Models.ScamType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

        private string searchEntry = string.Empty;
        public string SearchEntry
        {
            get => searchEntry;
            set
            {
                searchEntry = value;
                if (!string.IsNullOrEmpty(searchEntry))
                {
                    SearchEntryTextChangedCommand.Execute(searchEntry);
                };

                //SearchEntryTextChangedCommand.Execute(searchEntry);

                OnPropertyChanged(nameof(SearchEntry));
            }
        }

        public scamtypeViewModel(INavigation navigation)
        {
            Navigation = navigation;


            ScamType = new ObservableCollection<ScamTypeData>{
                new ScamTypeData { ScamType = "Vishing Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Smishing Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Investment Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Ransomware Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "ATM Skimming Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Gift Card Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Charity Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Romance Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Sweepstakes and Lottery Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Employment Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Business Email Compromise(BEC) Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Rental Scam", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Fake Invoice Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Government Scam", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Covid-19 Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Employment Opportunity Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Travel Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Tax Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Social Media Scams", DishImage = "scamarrowdown.png"},
                new ScamTypeData { ScamType = "Real Estate Scams", DishImage = "scamarrowdown.png"},

             };

            RealScamType = ScamType;
        }

        public Command SearchEntryTextChangedCommand => new Command<string>((_entryTxt) => SearchBar_TextChanged(_entryTxt));
        public Command SearchCommand { get; }

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
