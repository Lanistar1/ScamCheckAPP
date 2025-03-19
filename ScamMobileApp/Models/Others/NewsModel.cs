using ScamMobileApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Others
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class NewsData
    {
        public SearchParameters searchParameters { get; set; }
        public List<News> news { get; set; }
        public int credits { get; set; }
    }

    public class News
    {
        public string title { get; set; }
        public string link { get; set; }
        public string snippet { get; set; }
        public string date { get; set; }
        public string source { get; set; }
        public string imageUrl { get; set; }
        public int position { get; set; }
        public bool isSelected { get; set; }
    }

    public class NewsModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public NewsData data { get; set; }
    }

    public class SearchParameters
    {
        public string q { get; set; }
        public string gl { get; set; }
        public string type { get; set; }
        public string API { get; set; }
    }



}
