using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.ViewModels.FeedBack;
using ScamMobileApp.ViewModels.Others;
using ScamMobileApp.ViewModels.ScamCalculator;
using ScamMobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class FeedbackPopup : PopupPage, INotifyPropertyChanged
    {
        private string newComment;

        private int ratingNumber;



        private bool hideButton;
        public bool HideButton
        {
            get => hideButton;
            set
            {
                if (hideButton != value)
                {
                    hideButton = value;
                    OnPropertyChanged(nameof(HideButton));
                }
            }
        }

        private bool showButton;
        public bool ShowButton
        {
            get => showButton;
            set
            {
                if (showButton != value)
                {
                    showButton = value;
                    OnPropertyChanged(nameof(ShowButton));
                }
            }
        }

        public int StarRating { get; set; }

        PostRateViewModel pageViewModel = null;


        public FeedbackPopup()
        {
            InitializeComponent();

            // Initialize the star rating (e.g., 0 means no star)
            StarRating = 0;


            HideButton = true;
            ShowButton = false;

            UpdateButtonVisibility();

            BindingContext = this;

            pageViewModel = new PostRateViewModel(Navigation);
            InitializeComponent();
            BindingContext = pageViewModel;
        }

        

        private void UpdateButtonVisibility()
        {
            MessagingCenter.Subscribe<CustomStarControl, int>(this, "RatingNumber", (sender, RatingNumber) =>
            {
                ratingNumber = RatingNumber;
                Global.newRatingNumber = ratingNumber;

                if (ratingNumber == 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // Force a layout update if necessary
                        HideButton = true; // Show Button 1
                        ShowButton = false; // Hide Button 2
                    });
                    
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // Force a layout update if necessary
                        HideButton = false; // Hide Button 1
                        ShowButton = true; // Show Button 2
                    });
                    
                }
            });



            // Notify the UI that the properties have changed
            OnPropertyChanged(nameof(hideButton));
            OnPropertyChanged(nameof(showButton));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void cancel(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(); // Close the popup first
        }

        [Obsolete]
        private async void Close_Popup(object sender, EventArgs e)
        {
           
            await PopupNavigation.RemovePageAsync(this);
        }
    }



}