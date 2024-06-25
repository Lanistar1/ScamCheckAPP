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
using System.Numerics;
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

        private bool argentina = false;
        public bool Argentina
        {
            get => argentina;
            set
            {
                argentina = value;
                OnPropertyChanged(nameof(Argentina));
            }
        }

        private bool austria = false;
        public bool Austria
        {
            get => austria;
            set
            {
                austria = value;
                OnPropertyChanged(nameof(Austria));
            }
        }

        private bool belgium = false;
        public bool Belgium
        {
            get => belgium;
            set
            {
                belgium = value;
                OnPropertyChanged(nameof(Belgium));
            }
        }

        private bool brazil = false;
        public bool Brazil
        {
            get => brazil;
            set
            {
                brazil = value;
                OnPropertyChanged(nameof(Brazil));
            }
        }

        private bool bulgaria = false;
        public bool Bulgaria
        {
            get => bulgaria;
            set
            {
                bulgaria = value;
                OnPropertyChanged(nameof(Bulgaria));
            }
        }

        private bool czech = false;
        public bool Czech
        {
            get => czech;
            set
            {
                czech = value;
                OnPropertyChanged(nameof(Czech));
            }
        }

        private bool denmark = false;
        public bool Denmark
        {
            get => denmark;
            set
            {
                denmark = value;
                OnPropertyChanged(nameof(Denmark));
            }
        }

        private bool egypt = false;
        public bool Egypt
        {
            get => egypt;
            set
            {
                egypt = value;
                OnPropertyChanged(nameof(Egypt));
            }
        }

        private bool estonia = false;
        public bool Estonia
        {
            get => estonia;
            set
            {
                estonia = value;
                OnPropertyChanged(nameof(Estonia));
            }
        }

        private bool finland = false;
        public bool Finland
        {
            get => finland;
            set
            {
                finland = value;
                OnPropertyChanged(nameof(Finland));
            }
        }

        private bool greece = false;
        public bool Greece
        {
            get => greece;
            set
            {
                greece = value;
                OnPropertyChanged(nameof(Greece));
            }
        }

        private bool hungary = false;
        public bool Hungary
        {
            get => hungary;
            set
            {
                hungary = value;
                OnPropertyChanged(nameof(Hungary));
            }
        }

        private bool indonesia = false;
        public bool Indonesia
        {
            get => indonesia;
            set
            {
                indonesia = value;
                OnPropertyChanged(nameof(Indonesia));
            }
        }

        private bool latvia = false;
        public bool Latvia
        {
            get => latvia;
            set
            {
                latvia = value;
                OnPropertyChanged(nameof(Latvia));
            }
        }

        private bool lithuania = false;
        public bool Lithuania
        {
            get => lithuania;
            set
            {
                lithuania = value;
                OnPropertyChanged(nameof(Lithuania));
            }
        }

        private bool malaysia = false;
        public bool Malaysia
        {
            get => malaysia;
            set
            {
                malaysia = value;
                OnPropertyChanged(nameof(Malaysia));
            }
        }

        private bool mauritius = false;
        public bool Mauritius
        {
            get => mauritius;
            set
            {
                mauritius = value;
                OnPropertyChanged(nameof(Mauritius));
            }
        }

        private bool mexico = false;
        public bool Mexico
        {
            get => mexico;
            set
            {
                mexico = value;
                OnPropertyChanged(nameof(Mexico));
            }
        }

        private bool norway = false;
        public bool Norway
        {
            get => norway;
            set
            {
                norway = value;
                OnPropertyChanged(nameof(Norway));
            }
        }

        private bool pakistan = false;
        public bool Pakistan
        {
            get => pakistan;
            set
            {
                pakistan = value;
                OnPropertyChanged(nameof(Pakistan));
            }
        }

        private bool philippines = false;
        public bool Philippines
        {
            get => philippines;
            set
            {
                philippines = value;
                OnPropertyChanged(nameof(Philippines));
            }
        }

        private bool poland = false;
        public bool Poland
        {
            get => poland;
            set
            {
                poland = value;
                OnPropertyChanged(nameof(Poland));
            }
        }

        private bool portugal = false;
        public bool Portugal
        {
            get => portugal;
            set
            {
                portugal = value;
                OnPropertyChanged(nameof(Portugal));
            }
        }

        private bool romania = false;
        public bool Romania
        {
            get => romania;
            set
            {
                romania = value;
                OnPropertyChanged(nameof(Romania));
            }
        }

        private bool serbia = false;
        public bool Serbia
        {
            get => serbia;
            set
            {
                serbia = value;
                OnPropertyChanged(nameof(Serbia));
            }
        }

        private bool slovakia = false;
        public bool Slovakia
        {
            get => slovakia;
            set
            {
                slovakia = value;
                OnPropertyChanged(nameof(Slovakia));
            }
        }

        private bool slovenia = false;
        public bool Slovenia
        {
            get => slovenia;
            set
            {
                slovenia = value;
                OnPropertyChanged(nameof(Slovenia));
            }
        }

        private bool sri = false;
        public bool Sri
        {
            get => sri;
            set
            {
                sri = value;
                OnPropertyChanged(nameof(Sri));
            }
        }

        private bool sweden = false;
        public bool Sweden
        {
            get => sweden;
            set
            {
                sweden = value;
                OnPropertyChanged(nameof(Sweden));
            }
        }

        private bool thailand = false;
        public bool Thailand
        {
            get => thailand;
            set
            {
                thailand = value;
                OnPropertyChanged(nameof(Thailand));
            }
        }

        private bool turkey = false;
        public bool Turkey
        {
            get => turkey;
            set
            {
                turkey = value;
                OnPropertyChanged(nameof(Turkey));
            }
        }

        private bool croatia = false;
        public bool Croatia
        {
            get => croatia;
            set
            {
                croatia = value;
                OnPropertyChanged(nameof(Croatia));
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
                new SelectItemModel(2,"Argentina"),
                new SelectItemModel(3,"Austria"),
                new SelectItemModel(4,"Belgium"),
                new SelectItemModel(5,"Brazil"),
                new SelectItemModel(6,"Bulgaria"),
                new SelectItemModel(7,"Canada"),
                new SelectItemModel(8,"Croatia"),
                new SelectItemModel(9,"Czech Republic"),
                new SelectItemModel(10,"Denmark"),
                new SelectItemModel(11,"Egypt"),
                new SelectItemModel(12,"Estonia"),
                new SelectItemModel(13,"Finland"),
                new SelectItemModel(14,"France"),
                new SelectItemModel(15,"Germany"),
                new SelectItemModel(16,"Greece"),
                new SelectItemModel(17,"Hungary"),
                new SelectItemModel(18,"India"),
                new SelectItemModel(19,"Indonesia"),
                new SelectItemModel(20,"Ireland"),
                new SelectItemModel(21,"Israel"),
                new SelectItemModel(22,"Italy"),
                new SelectItemModel(23,"Japan"),
                new SelectItemModel(24,"Latvia"),
                new SelectItemModel(25,"Lithuania"),
                new SelectItemModel(26,"Malaysia"),
                new SelectItemModel(27,"Mauritius"),
                new SelectItemModel(28,"Mexico"),
                new SelectItemModel(29,"Netherland"),
                new SelectItemModel(30,"New Zealand"),
                new SelectItemModel(31,"Norway"),
                new SelectItemModel(32,"Pakistan"),
                new SelectItemModel(33,"Philippines"),
                new SelectItemModel(34,"Poland"),
                new SelectItemModel(35,"Portugal"),
                new SelectItemModel(36,"Romania"),
                new SelectItemModel(37,"Saudi Arabia"),
                new SelectItemModel(38,"Serbia"),
                new SelectItemModel(39,"Singapore"),
                new SelectItemModel(40,"Slovakia"),
                new SelectItemModel(41,"Slovenia"),
                new SelectItemModel(42,"South Africa"),
                new SelectItemModel(43,"South Korea"),
                new SelectItemModel(44,"Spain"),
                new SelectItemModel(45,"Sri Lanka"),
                new SelectItemModel(46,"Sweden"),
                new SelectItemModel(47,"Switzerland"),
                new SelectItemModel(48,"Thailand"),
                new SelectItemModel(49,"Turkey"),
                new SelectItemModel(50,"Ukraine"),
                new SelectItemModel(51,"United Arab Emirate"),
                new SelectItemModel(52,"United Kingdom"),
                new SelectItemModel(53,"United State of America"),

            };
            var popup = new SelectItemPickerPopup(responseToLightTypes);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            Title = result.Item1;


            if (Title == "Australia")
            {
                Australia = true;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Canada")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = true;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "France")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = true;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Germany")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = true;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "India")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = true;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Ireland")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = true;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Israel")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = true;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Italy")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = true;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Japan")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = true;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "New Zealand")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = true;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Saudi Arabia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = true;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Singapore")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = true;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "South Africa")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = true;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "South Korea")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = true;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Spain")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = true;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Switzerland")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = true;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Ukraine")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = true;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "United Arab Emirate")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = true;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "United Kingdom")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = true;
                USA = false;
            }
            else if (Title == "United State of America")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = true;
            }
            else if (Title == "Argentina")
            {
                Australia = false;
                Argentina = true;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Austria")
            {
                Australia = false;
                Argentina = false;
                Austria = true;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Belgium")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = true;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Brazil")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = true;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Bulgaria")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = true;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Czech Republic")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = true;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Denmark")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = true;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Egypt")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = true;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Estonia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = true;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Finland")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = true;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Greece")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = true;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Hungary")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = true;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Indonesia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = true;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Latvia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = true;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Lithuania")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = true;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Malaysia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = true;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Mauritius")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = true;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Mexico")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = true;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Netherland")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = true;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Norway")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = true;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Pakistan")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = true;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Philippines")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = true;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Poland")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = true;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Portugal")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = true;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Romania")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = true;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Serbia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = true;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Slovakia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = true;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Slovenia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = true;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Sri Lanka")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = true;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Sweden")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = true;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Thailand")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = true;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Turkey")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = false;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = true;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }
            else if (Title == "Croatia")
            {
                Australia = false;
                Argentina = false;
                Austria = false;
                Belgium = false;
                Brazil = false;
                Bulgaria = false;
                Canada = false;
                Croatia = true;
                Czech = false;
                Denmark = false;
                Egypt = false;
                Estonia = false;
                Finland = false;
                France = false;
                Germany = false;
                Greece = false;
                Hungary = false;
                India = false;
                Indonesia = false;
                Ireland = false;
                Israel = false;
                Italy = false;
                Japan = false;
                Latvia = false;
                Lithuania = false;
                Malaysia = false;
                Mauritius = false;
                Mexico = false;
                Netherland = false;
                Zealand = false;
                Norway = false;
                Pakistan = false;
                Philippines = false;
                Poland = false;
                Portugal = false;
                Romania = false;
                Saudi = false;
                Serbia = false;
                Singapore = false;
                Slovakia = false;
                Slovenia = false;
                SAfrica = false;
                SKorea = false;
                Spain = false;
                Sri = false;
                Sweden = false;
                Switzerland = false;
                Thailand = false;
                Turkey = false;
                Ukraine = false;
                UAE = false;
                UnitedK = false;
                USA = false;
            }

        }


        #endregion
    }

}
