using System;
using ScamMobileApp.Controls;
using ScamMobileApp.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace ScamMobileApp.iOS.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove border and background
                Control.BorderStyle = UITextBorderStyle.None;

                // Set background color to transparent
                Control.BackgroundColor = UIColor.Clear;

                // Optionally set other properties like text color, font, etc.
                // Control.TextColor = UIColor.Black;
                // Control.Font = UIFont.SystemFontOfSize(16);
            }
        }
    }
}

