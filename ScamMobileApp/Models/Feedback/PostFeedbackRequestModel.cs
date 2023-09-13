using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Feedback
{
    public class QuestionAnswerData
    {
        public string question { get; set; }
        public string answer { get; set; }
    }

    public class PostFeedbackRequestModel
    {
        public string output { get; set; }
        public List<QuestionAnswerData> questionAnswer { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
    }


}
