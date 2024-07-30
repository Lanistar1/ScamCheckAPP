using Rg.Plugins.Popup.Services;
using ScamMobileApp.Models;
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

namespace ScamMobileApp.ViewModels.Home
{
    public class OthersViewModel : BaseViewModel
    {
        public OthersViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ScamQA = "ScamQ&A";
            Title = "Start ScamQ&A";

            ContentList = new List<MoreModel>
            {
                new MoreModel { Name = "Report Scam", Image = "scamreportt.png"},
                new MoreModel { Name = "Help Center", Image = "scamreportt.png"},
                new MoreModel { Name = "Terms", Image = "scamtermss.png"},
                new MoreModel { Name = "Change Password", Image = "scamchangee.png"},
                new MoreModel { Name = "Types of Scam", Image = "scamtypee.png"},
                new MoreModel { Name = "ScamQ&A", Image = "scamqaa.png"},
                new MoreModel { Name = "Anti-Scam Movement", Image = "scamanti.png"},
                new MoreModel { Name = "Preventive Tips", Image = "scamtipss.png"},
                new MoreModel { Name = "Warning Signs", Image = "scamwarnn.png"},
                

            };

            TappedCommand = new Command<MoreModel>( (model) => GetTappedExecute(model));

        }

        public Command TappedCommand { get; }

        #region Binding Properties
        private List<MoreModel> contentList;
        public List<MoreModel> ContentList
        {
            get => contentList;
            set
            {
                contentList = value;
                OnPropertyChanged(nameof(ContentList));
            }
        }

        private List<MoreModel> selectedItems;
        public List<MoreModel> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
                OnPropertyChanged(nameof(SelectedItems));
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

        #endregion

        private void GetTappedExecute(MoreModel model)
        {
            try
            {
                if (model.Name.Contains("Report Scam"))
                {

                    //await Navigation.PushAsync(new GreetingPage());

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }

}
