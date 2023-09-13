using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Feedback
{

    public class GetFeedbackData
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string comment { get; set; }
        public int? rating { get; set; }
        public List<QuestionAnswer> questionAnswer { get; set; }
        public string output { get; set; }
        public string userId { get; set; }
        public UserDetails userDetails { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
    }

    public class QuestionAnswer
    {
        public string question { get; set; }
        public string answer { get; set; }
    }

    public class GetFeedbackModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<GetFeedbackData> data { get; set; }
    }

    public class UserDetails
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string _id { get; set; }
        public string username { get; set; }
    }

}
