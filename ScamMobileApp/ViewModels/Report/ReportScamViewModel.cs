using Rg.Plugins.Popup.Services;
using ScamMobileApp.Models.Popup;
using ScamMobileApp.Popup;
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
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.Report
{

    public class ReportScamViewModel : BaseViewModel
    {
        public ReportScamViewModel(INavigation navigation)
        {
            Navigation = navigation;

            SelectPageCommand = new Command(async () => await SelectPageCommandExecute());

            ScamQA = "ScamQ&A";
            Message = "You can explore our \"Questions and Answers\" section to assess whether your suspicions regarding an email, message, chat, etc., indicate a potential scam. By answering four questions related to the type of scam you select, we can assist you in determining whether you have fallen victim to a scam or not.";

        }

        #region Binding Properties


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


        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
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

        private bool scamCheck;
        public bool ScamCheck
        {
            get => scamCheck;
            set
            {
                scamCheck = value;
                OnPropertyChanged(nameof(ScamCheck));
            }
        }

        private bool australia = false;
        public bool Australia
        {
            get => australia;
            set
            {
                australia = value;
                OnPropertyChanged(nameof(Australia));
            }
        }

        private bool canada = false;
        public bool Canada
        {
            get => canada;
            set
            {
                canada = value;
                OnPropertyChanged(nameof(Canada));
            }
        }

        private bool france = false;
        public bool France
        {
            get => france;
            set
            {
                france = value;
                OnPropertyChanged(nameof(France));
            }
        }

        private bool germany = false;
        public bool Germany
        {
            get => germany;
            set
            {
                germany = value;
                OnPropertyChanged(nameof(Germany));
            }
        }

        private bool india = false;
        public bool India
        {
            get => india;
            set
            {
                india = value;
                OnPropertyChanged(nameof(India));
            }
        }

        private bool ireland = false;
        public bool Ireland
        {
            get => ireland;
            set
            {
                ireland = value;
                OnPropertyChanged(nameof(Ireland));
            }
        }

        private bool israel = false;
        public bool Israel
        {
            get => israel;
            set
            {
                israel = value;
                OnPropertyChanged(nameof(Israel));
            }
        }

        private bool italy = false;
        public bool Italy
        {
            get => italy;
            set
            {
                italy = value;
                OnPropertyChanged(nameof(Italy));
            }
        }

        private bool japan = false;
        public bool Japan
        {
            get => japan;
            set
            {
                japan = value;
                OnPropertyChanged(nameof(Japan));
            }
        }

        private bool netherland = false;
        public bool Netherland
        {
            get => netherland;
            set
            {
                netherland = value;
                OnPropertyChanged(nameof(Netherland));
            }
        }

        private bool zealand = false;
        public bool Zealand
        {
            get => zealand;
            set
            {
                zealand = value;
                OnPropertyChanged(nameof(Zealand));
            }
        }

        private bool saudi = false;
        public bool Saudi
        {
            get => saudi;
            set
            {
                saudi = value;
                OnPropertyChanged(nameof(Saudi));
            }
        }

        private bool singapore = false;
        public bool Singapore
        {
            get => singapore;
            set
            {
                singapore = value;
                OnPropertyChanged(nameof(Singapore));
            }
        }

        private bool sAfrica = false;
        public bool SAfrica
        {
            get => sAfrica;
            set
            {
                sAfrica = value;
                OnPropertyChanged(nameof(SAfrica));
            }
        }

        private bool sKorea = false;
        public bool SKorea
        {
            get => sKorea;
            set
            {
                sKorea = value;
                OnPropertyChanged(nameof(SKorea));
            }
        }

        private bool spain = false;
        public bool Spain
        {
            get => spain;
            set
            {
                spain = value;
                OnPropertyChanged(nameof(Spain));
            }
        }

        private bool switzerland = false;
        public bool Switzerland
        {
            get => switzerland;
            set
            {
                switzerland = value;
                OnPropertyChanged(nameof(Switzerland));
            }
        }

        private bool ukraine = false;
        public bool Ukraine
        {
            get => ukraine;
            set
            {
                ukraine = value;
                OnPropertyChanged(nameof(Ukraine));
            }
        }

        private bool uAE = false;
        public bool UAE
        {
            get => uAE;
            set
            {
                uAE = value;
                OnPropertyChanged(nameof(UAE));
            }
        }

        private bool unitedK = false;
        public bool UnitedK
        {
            get => unitedK;
            set
            {
                unitedK = value;
                OnPropertyChanged(nameof(UnitedK));
            }
        }

        private bool uSA = false;
        public bool USA
        {
            get => uSA;
            set
            {
                uSA = value;
                OnPropertyChanged(nameof(USA));
            }
        }
        #endregion


        #region Events, Methods, Functions and Navigations
        public Command PostExerienceCommand { get; }
        public Command SelectPageCommand { get; }

        #endregion

        #region

        private async Task SelectPageCommandExecute()
        {

            List<SelectItemModel> responseToLightTypes = new List<SelectItemModel>()
            {
                new SelectItemModel(1,"Australia"),
                new SelectItemModel(2,"Canada"),
                new SelectItemModel(3,"France"),
                new SelectItemModel(4,"Germany"),
                new SelectItemModel(5,"India"),
                new SelectItemModel(6,"Ireland"),
                new SelectItemModel(7,"Israel"),
                new SelectItemModel(8,"Italy"),
                new SelectItemModel(9,"Japan"),
                new SelectItemModel(10,"New Zealand"),
                new SelectItemModel(11,"Saudi Arabia"),
                new SelectItemModel(12,"Singapore"),
                new SelectItemModel(13,"South Africa"),
                new SelectItemModel(14,"South Korea"),
                new SelectItemModel(15,"Spain"),
                new SelectItemModel(16,"Switzerland"),
                new SelectItemModel(17,"Ukraine"),
                new SelectItemModel(18,"United Arab Emirate"),
                new SelectItemModel(19,"United Kingdom"),
                new SelectItemModel(20,"United State of America"),

            };
            var popup = new SelectItemPickerPopup(responseToLightTypes);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            Title = result.Item1;



            if (Title == "Australia")
            {
                Australia = true;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Canada")
            {
                Australia = false;
                Canada = true;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "France")
            {
                Australia = false;
                Canada = false;
                France = true;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Germany")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = true;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "India")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = true;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Ireland")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = true;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Israel")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = true;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Italy")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = true;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Japan")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = true;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "New Zealand")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = true;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Saudi Arabia")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = true;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Singapore")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = true;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "South Africa")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = true;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "South Korea")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = true;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Spain")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = true;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Switzerland")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = true;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Ukraine")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = true;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "United Arab Emirate")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = true;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "United Kingdom")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = true;
                USA = false;
            }
            else if (Title == "United State of America")
            {
                Australia = false;
                Canada = false;
                France = false;
                Germany = false;
                India = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Zealand = false;
                Saudi = false;
                Singapore = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Switzerland = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = true;
            }
        }


        #endregion
    }

}
