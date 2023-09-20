using Rg.Plugins.Popup.Services;
using ScamMobileApp.Models.Popup;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Identity;
using ScamMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ScamMobileApp.Views.Questions.Vishing;
using ScamMobileApp.Views.Questions.Phishing;
using ScamMobileApp.Views.Questions.Smishing;
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
using ScamMobileApp.Views.Questions.QRcode;
using ScamMobileApp.Views.Questions.Ransomware;
using ScamMobileApp.Views.Questions.Romance;
using ScamMobileApp.Views.Questions.SocialMedia;
using ScamMobileApp.Views.Questions.Tax;
using ScamMobileApp.Views.Questions.Tech;
using ScamMobileApp.Views.Questions.Business;
using ScamMobileApp.Views.Questions.ATM;

namespace ScamMobileApp.ViewModels.Home
{
    public class ScamQuestionAndAnswerViewModel : BaseViewModel
    {
        public ScamQuestionAndAnswerViewModel(INavigation navigation)
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
                new SelectItemModel(1,"PHISHING SCAM"),
                new SelectItemModel(2,"VISHING SCAM"),
                new SelectItemModel(3,"SMISHING SCAM"),
                new SelectItemModel(4,"INVESTMENT SCAM"),
                new SelectItemModel(5,"ROMANCE SCAM"),
                new SelectItemModel(6,"QR CODE SCAMS"),
                new SelectItemModel(7,"IMPERSONATION SCAM"),
                new SelectItemModel(8,"RANSOMWARE  SCAM"),
                new SelectItemModel(9,"ATM SKIMMING SCAM"),
                new SelectItemModel(10,"TECH SUPPORT SCAM"),
                new SelectItemModel(11,"BUSINESS EMAIL COMPROMISE(BEC) SCAM"),
                new SelectItemModel(12,"LOTTERY, PRIZE OR FREE GIFTS SCAM"),
                new SelectItemModel(13,"SOCIAL MEDIA  SCAM"),
                new SelectItemModel(14,"TAX SCAM"),
                new SelectItemModel(15,"IDENTITY THEFT SCAM"),
                new SelectItemModel(16,"GRANDPARENT OR PARENT SCAM"),
                new SelectItemModel(17,"CHARITY SCAM"),
                new SelectItemModel(18,"ONLINE SHOPPING SCAM"),
                new SelectItemModel(19,"EMPLOYMENT OPPORTUNITY SCAM"),
                new SelectItemModel(20,"FAKE INVOICE SCAM"),
                new SelectItemModel(21,"GIFT CARD SCAM"),

            };
            var popup = new SelectItemPickerPopup(responseToLightTypes);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            Title = result.Item1;



            if (Title == "PHISHING SCAM")
            {
                await Navigation.PushAsync(new PhishingFirstQuestion());
            }
            else if (Title == "VISHING SCAM")
            {
                await Navigation.PushAsync(new VishingFirstQuestion());
            }
            else if (Title == "SMISHING SCAM")
            {
                await Navigation.PushAsync(new SmishingFirstQuestion());
            }
            else if (Title == "INVESTMENT SCAM")
            {
                await Navigation.PushAsync(new InvestmentFirstQuestion());
            }
            else if (Title == "ROMANCE SCAM")
            {
                await Navigation.PushAsync(new RomanceFirstQuestion());
            }
            else if (Title == "QR CODE SCAMS")
            {
                await Navigation.PushAsync(new QRcodeFirstQuestion());
            }
            else if (Title == "IMPERSONATION SCAM")
            {
                await Navigation.PushAsync(new ImpersonationFirstQuestion());
            }
            else if (Title == "RANSOMWARE  SCAM")
            {
                await Navigation.PushAsync(new RansomewareFirstQuestion());
            }
            else if (Title == "ATM SKIMMING SCAM")
            {
                await Navigation.PushAsync(new ATMFirstQuestion());
            }
            else if (Title == "TECH SUPPORT SCAM")
            {
                await Navigation.PushAsync(new TechFirstQuestion());
            }
            else if (Title == "BUSINESS EMAIL COMPROMISE(BEC) SCAM")
            {
                await Navigation.PushAsync(new BusinessFirstQuestion());
            }
            else if (Title == "LOTTERY, PRIZE OR FREE GIFTS SCAM")
            {
                await Navigation.PushAsync(new LotteryFirstQuestion());
            }
            else if (Title == "SOCIAL MEDIA  SCAM")
            {
                await Navigation.PushAsync(new SocialMediaFirstQuestion());
            }
            else if (Title == "TAX SCAM")
            {
                await Navigation.PushAsync(new TaxFirstQuestion());
            }
            else if (Title == "IDENTITY THEFT SCAM")
            {
                await Navigation.PushAsync(new IdentityfirstQuestion());
            }
            else if (Title == "GRANDPARENT OR PARENT SCAM")
            {
                await Navigation.PushAsync(new GrandParentFirstQuestion());
            }
            else if (Title == "CHARITY SCAM")
            {
                await Navigation.PushAsync(new CharityFirstQuestion());
            }
            else if (Title == "ONLINE SHOPPING SCAM")
            {
                await Navigation.PushAsync(new OnlineShoppingFirstQuestion());
            }
            else if (Title == "EMPLOYMENT OPPORTUNITY SCAM")
            {
                await Navigation.PushAsync(new EmploymentFirstQuestion());
            }
            else if (Title == "FAKE INVOICE SCAM")
            {
                await Navigation.PushAsync(new FakeFirstQuestion());
            }
            else if (Title == "GIFT CARD SCAM")
            {
                await Navigation.PushAsync(new GiftCardFirstQuestion());
            }
        }

       
        #endregion
    }

}
