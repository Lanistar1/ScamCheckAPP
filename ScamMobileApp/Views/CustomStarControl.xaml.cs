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
        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(nameof(Rating), typeof(int), typeof(CustomStarControl), 0, propertyChanged: RatingPropertyChanged);

        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        public event EventHandler<int> RatingChanged;

        private static void RatingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomStarControl)bindable;
            int rating = (int)newValue;

            // Show/hide filled star based on the rating value
            control.filledStar.IsVisible = rating > 0;

            // Raise the RatingChanged event
            control.OnRatingChanged(rating);
        }

        private void OnRatingChanged(int newRating)
        {
            RatingChanged?.Invoke(this, newRating);
        }

        public CustomStarControl()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                // Toggle the rating when the star is tapped
                Rating = Rating == 0 ? 1 : 0;
            };

            // Add the tap gesture to the grid
            emptyStar.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}