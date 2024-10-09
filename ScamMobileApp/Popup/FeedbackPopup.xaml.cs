using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
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

        public FeedbackPopup()
        {
            InitializeComponent();

            // Initialize the star rating (e.g., 0 means no star)
            StarRating = 0;

            //ratingNumber = 0;

            //if (ratingNumber == 0)
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        // Force a layout update if necessary
            //        hideButton = true; // Show Button 1
            //        showButton = false; // Hide Button 2
            //    });

            //}
            //else
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        // Force a layout update if necessary
            //        hideButton = false; // Hide Button 1
            //        showButton = true; // Show Button 2
            //    });

            //}

            HideButton = true;
            ShowButton = false;

            UpdateButtonVisibility();

            BindingContext = this;
        }

        

        private void UpdateButtonVisibility()
        {
            MessagingCenter.Subscribe<CustomStarControl, int>(this, "RatingNumber", (sender, RatingNumber) =>
            {
                ratingNumber = RatingNumber;

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


            //var test = Global.Rating;

            //string newTest = test.ToString();

            //if (ratingNumber == 0)
            //{
            //    hideButton = true; // Show Button 1
            //    showButton = false; // Hide Button 2
            //}
            //else
            //{
            //    hideButton = false; // Hide Button 1
            //    showButton = true; // Show Button 2
            //}

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

        private async void Close_Popup(object sender, EventArgs e)
        {
            newComment = comment.Text;
            Global.comment = newComment;

            await PopupNavigation.Instance.PopAsync(); // Close the popup first

            //await PopupNavigation.RemovePageAsync(this);
        }
    }



    //public partial class FeedbackPopup : PopupPage
    //{
    //    private string newComment;

    //    public int Star1Rating { get; set; }
    //    public int Star2Rating { get; set; }
    //    public int Star3Rating { get; set; }
    //    public int Star4Rating { get; set; }
    //    public int Star5Rating { get; set; }

    //    public int TotalRating { get; set; }

    //    public FeedbackPopup()
    //    {
    //        InitializeComponent();
    //        BindingContext = new ATMViewModel(Navigation);

    //        // Initialize the star ratings (e.g., 0 means no star)
    //        Star1Rating = 0;
    //        Star2Rating = 0;
    //        Star3Rating = 0;
    //        Star4Rating = 0;
    //        Star5Rating = 0;

    //        //BindingContext = this;

    //        // Subscribe to the RatingChanged event for each star
    //        //star1.RatingChanged += OnStarRatingChanged;
    //        //star2.RatingChanged += OnStarRatingChanged;
    //        //star3.RatingChanged += OnStarRatingChanged;
    //        //star4.RatingChanged += OnStarRatingChanged;
    //        //star5.RatingChanged += OnStarRatingChanged;

    //        // Calculate the initial total rating
    //        CalculateTotalRating();
    //    }

    //    private void OnStarRatingChanged(object sender, int newRating)
    //    {
    //        // Update the corresponding star rating
    //        if (sender == star1)
    //        {
    //            Star1Rating = newRating;
    //        }
    //        else if (sender == star2)
    //        {
    //            Star2Rating = newRating;
    //        }
    //        else if (sender == star3)
    //        {
    //            Star3Rating = newRating;
    //        }
    //        else if (sender == star4)
    //        {
    //            Star4Rating = newRating;
    //        }
    //        else if (sender == star5)
    //        {
    //            Star5Rating = newRating;
    //        }

    //        // Recalculate the total rating
    //        CalculateTotalRating();
    //    }

    //    private void CalculateTotalRating()
    //    {
    //        // Calculate the total rating by summing individual star ratings
    //        TotalRating = Star1Rating + Star2Rating + Star3Rating + Star4Rating + Star5Rating;

    //        Global.Rating = TotalRating;
    //    }

    //    private void Close_Popup(object sender, EventArgs e)
    //    {
    //        newComment = comment.Text;
    //        Global.comment = newComment;
    //        PopupNavigation.RemovePageAsync(this);
    //    }
    //}
}