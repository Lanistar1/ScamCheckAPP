using ScamMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.Models.Experience
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ExperienceData : BaseViewModel
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public string title { get; set; }
        public string userId { get; set; }
        public UserDetailsData userDetails { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
        public bool isSelected { get; set; }

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

        public string Description => IsExpanded ? message : $"{message.Substring(0, Math.Min(message.Length, 50))}...";

        public string ReadMoreText => IsExpanded ? "Read Less" : "Read More";

        public ImageSource ReadMoreArrow => IsExpanded ? "readMore.png" : "readMore.png";
    }

    public class GetExperienceModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public ObservableCollection<ExperienceData> data { get; set; }
    }

    public class UserDetailsData
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string _id { get; set; }
        public string username { get; set; }
    }


}
