using ScamMobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // CustomStarControl.xaml.cs


    public partial class CustomStarControl : ContentView
    {
        private Image[] stars;

        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(nameof(Rating), typeof(int), typeof(CustomStarControl), 0, propertyChanged: RatingChanged);

        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        private static void RatingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStarControl)bindable;
            int rating = (int)newValue;

            // Update the appearance of the stars based on the rating value
            for (int i = 0; i < control.stars.Length; i++)
            {
                control.stars[i].Source = i < rating ? "fillstar.png" : "emptystar.png";
            }
        }

        public CustomStarControl()
        {
            InitializeComponent();

            stars = new Image[] { star1, star2, star3, star4, star5 };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnStarTapped;

            // Add the tap gesture to each star
            foreach (var star in stars)
            {
                star.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        private void OnStarTapped(object sender, EventArgs e)
        {
            var tappedStar = (Image)sender;
            int starNumber = Array.IndexOf(stars, tappedStar) + 1;

            // Set the rating to the star number and update the appearance
            Rating = starNumber;

            Global.Rating = Rating;

        }
    }
}