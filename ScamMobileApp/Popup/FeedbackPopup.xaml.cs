﻿using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.ViewModels.ScamCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class FeedbackPopup : PopupPage
    {
        private string newComment;

        public int StarRating { get; set; }

        public FeedbackPopup()
        {
            InitializeComponent();

            // Initialize the star rating (e.g., 0 means no star)
            StarRating = 0;

            BindingContext = this;
        }

        private void cancel(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(); // Close the popup first
        }

        private async void Close_Popup(object sender, EventArgs e)
        {
            newComment = comment.Text;
            Global.comment = newComment;
            await PopupNavigation.RemovePageAsync(this);
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