using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ScamMobileApp.Models.Experience
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ExperienceData
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
