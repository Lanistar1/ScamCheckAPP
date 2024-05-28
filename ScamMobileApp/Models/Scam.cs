using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.Models
{
    public class Scam : BindableObject
    {
        public string Title { get; set; }
        public string FullDescription { get; set; }
        private bool isExpanded;

        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                if (isExpanded != value)
                {
                    isExpanded = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Description));
                    OnPropertyChanged(nameof(ReadMoreText));
                    OnPropertyChanged(nameof(ReadMoreArrow));
                }
            }
        }

        public string Description => IsExpanded ? FullDescription : $"{FullDescription.Substring(0, Math.Min(FullDescription.Length, 100))}...";

        public string ReadMoreText => IsExpanded ? "Read Less" : "Read More";

        public ImageSource ReadMoreArrow => IsExpanded ? "arrowup1.png" : "arrowdown1.png";
    }

}
