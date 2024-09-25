using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Feedback
{
    public class CountData
    {
        public int likelyScamCount { get; set; }
        public int unlikelyScamCount { get; set; }
    }

    public class FeedbackCountModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public CountData data { get; set; }
    }

}
