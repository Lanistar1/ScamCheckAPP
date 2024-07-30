using ScamMobileApp.ViewModels.Identity;
using ScamMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
using ScamMobileApp.Popup;
using System.Net.Http.Headers;
using System.Net.Http;
using Xamarin.Essentials;
using System.IO;
using Newtonsoft.Json;
using ScamMobileApp.Models.Identity;
using ScamMobileApp.Helpers;
using ScamMobileApp.Utils;


namespace ScamMobileApp.Views.More
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        //private FileResult _selectedImage;
        //public bool IsImageSelected => _selectedImage != null;

        private string PImage { get; set; }

        GetProfileViewModel pageViewModel = null;

        public ProfilePage()
        {
            pageViewModel = new GetProfileViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;

            PImage = "myprofile.png";
        }

        private void DeleteAccount(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new DeleteAccountPopup());
        }

       
    }
}