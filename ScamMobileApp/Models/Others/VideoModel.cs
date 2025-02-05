using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ScamMobileApp.Models.Others
{
    //public class VideoModel
    //{
    //    public string Title { get; set; } // Optional, for display
    //    public string VideoUrl { get; set; }
    //    public string ThumbnailUrl { get; set; }
    //    public bool isSelected { get; set; }
    //}


    public class VideoData
    {
        public string _id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
        public bool isSelected { get; set; }
        public string thumbnailUrl { get; set; }
    }

    public class VideoModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public ObservableCollection<VideoData> data { get; set; }
    }

}
