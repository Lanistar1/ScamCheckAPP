using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Facebook;
using Xamarin.Facebook.AppEvents;
using Firebase;
using Android.Util;

namespace ScamMobileApp.Droid
{
    [Activity(Label = "SCAMalicious", Icon = "@drawable/scamicon1", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Plugin.Media.CrossMedia.Current.Initialize(); // Initialize the media plugin

            // Initialize Facebook SDK
            FacebookSdk.SdkInitialize(ApplicationContext);
            // Track App Launch Event
            AppEventsLogger.ActivateApp(this.Application);

            // Firebase integration
            //FirebaseApp.InitializeApp(this);
            Firebase.FirebaseApp.InitializeApp(this);

            //Firebase.FirebaseApp.InitializeApp(Application.Context);

            //Firebase.Analytics.FirebaseAnalytics.GetInstance(Application.Context).SetAnalyticsCollectionEnabled(true);
            //// Firebase Analytics event logging
            //var firebaseAnalytics = Firebase.Analytics.FirebaseAnalytics.GetInstance(Application.Context);
            //var bundle = new Bundle();
            //bundle.PutString("test_param", "test_value");
            //firebaseAnalytics.LogEvent("test_event", bundle);



            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
        }


    }
}