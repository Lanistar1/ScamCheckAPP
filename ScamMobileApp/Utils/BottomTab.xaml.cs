using ScamMobileApp.ViewModels.Home;
using ScamMobileApp.Views.Experience;
using ScamMobileApp.Views.Feedback;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.More;
using ScamMobileApp.Views.Questions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Utils
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomTab : ContentView
    {
        public BottomTab()
        {
            InitializeComponent();
            BindingContext = new ScamQuestionAndAnswerViewModel(Navigation);

        }

        #region Current Page
        public static readonly BindableProperty CurrentPageProperty = BindableProperty.Create(nameof(CurrentPage), typeof(string), typeof(BottomTab), string.Empty);
        public string CurrentPage
        {
            get => (string)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }
        #endregion

        #region Home
        public static readonly BindableProperty HomeIconProperty = BindableProperty.Create(nameof(hmImgSource), typeof(string), typeof(BottomTab), string.Empty);
        public string hmImgSource
        {
            get => (string)GetValue(HomeIconProperty);
            set => SetValue(HomeIconProperty, value);
        }
        public static readonly BindableProperty LabelColorProperty = BindableProperty.Create(nameof(hmLabelColor), typeof(Color), typeof(BottomTab), Color.Accent);
        public Color hmLabelColor
        {
            get => (Color)GetValue(LabelColorProperty);
            set => SetValue(LabelColorProperty, value);
        }

        public static readonly BindableProperty HomeButtonColorProperty = BindableProperty.Create(
            nameof(hmButtonColor),
            typeof(Color),
            typeof(BottomTab),
            Color.Transparent // Default color
        );

        public Color hmButtonColor
        {
            get => (Color)GetValue(HomeButtonColorProperty);
            set => SetValue(HomeButtonColorProperty, value);
        }
        #endregion

        #region Customer
        public static readonly BindableProperty CustomerIconProperty = BindableProperty.Create(nameof(cusImgSource), typeof(string), typeof(BottomTab), string.Empty);
        public string cusImgSource
        {
            get => (string)GetValue(CustomerIconProperty);
            set => SetValue(CustomerIconProperty, value);
        }

        public static readonly BindableProperty subLabelColorProperty = BindableProperty.Create(nameof(cusLabelColor), typeof(Color), typeof(BottomTab), Color.Accent);
        public Color cusLabelColor
        {
            get => (Color)GetValue(subLabelColorProperty);
            set => SetValue(subLabelColorProperty, value);
        }
        #endregion

        #region Collection
        public static readonly BindableProperty CollectionIconProperty = BindableProperty.Create(nameof(colImgSource), typeof(string), typeof(BottomTab), string.Empty);
        public string colImgSource
        {
            get => (string)GetValue(CollectionIconProperty);
            set => SetValue(CollectionIconProperty, value);
        }

        public static readonly BindableProperty CollectionLabelColorProperty = BindableProperty.Create(nameof(colLabelColor), typeof(Color), typeof(BottomTab), Color.Accent);
        public Color colLabelColor
        {
            get => (Color)GetValue(CollectionLabelColorProperty);
            set => SetValue(CollectionLabelColorProperty, value);
        }
        #endregion

        #region Profile
        public static readonly BindableProperty ProfileIconProperty = BindableProperty.Create(nameof(profileImgSource), typeof(string), typeof(BottomTab), string.Empty);
        public string profileImgSource
        {
            get => (string)GetValue(ProfileIconProperty);
            set => SetValue(ProfileIconProperty, value);
        }

        public static readonly BindableProperty profileLabelColorProperty = BindableProperty.Create(nameof(profileLabelColor), typeof(Color), typeof(BottomTab), Color.Accent);
        public Color profileLabelColor
        {
            get => (Color)GetValue(profileLabelColorProperty);
            set => SetValue(profileLabelColorProperty, value);
        }
        #endregion

        #region More
        public static readonly BindableProperty MoreIconProperty = BindableProperty.Create(nameof(moreImgSource), typeof(string), typeof(BottomTab), string.Empty);
        public string moreImgSource
        {
            get => (string)GetValue(MoreIconProperty);
            set => SetValue(MoreIconProperty, value);
        }

        public static readonly BindableProperty moreLabelColorProperty = BindableProperty.Create(nameof(moreLabelColor), typeof(Color), typeof(BottomTab), Color.Accent);
        public Color moreLabelColor
        {
            get => (Color)GetValue(moreLabelColorProperty);
            set => SetValue(moreLabelColorProperty, value);
        }
        #endregion

        private void HomeIcon_Tapped(object sender, EventArgs e)
        {
            if (CurrentPage == "NewDashboard")
            {
                return;
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new NewDashboard());
            }
        }

        private async void CustomerIcon_Tapped(object sender, EventArgs e)
        {
            if (CurrentPage == "QuestionsAndAnswer")
            {
                return;
            }
            else
            {
                await Navigation.PushAsync(new QuestionsAndAnswer(), true);
            }
        }

        private async void CollectionIcon_Tapped(object sender, EventArgs e)
        {
            if (CurrentPage == "MyStory")
            {
                return;
            }
            else
            {
                await Navigation.PushAsync(new MyStory(), true);
            }
        }

        private async void ProfileIcon_Tapped(object sender, EventArgs e)
        {
            if (CurrentPage == "AllFeedbackPage")
            {
                return;
            }
            else
            {
                await Navigation.PushAsync(new AllFeedbackPage(), true);
            }
        }


        private async void MoreIcon_Tapped(object sender, EventArgs e)
        {
            if (CurrentPage == "MoreMenu")
            {
                return;
            }
            else
            {
                await Navigation.PushAsync(new MoreMenu(), true);
            }
        }
    }
}