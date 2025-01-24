using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Others
{

    public class TriviaQuestionModel
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Metadata { get; set; }
    }

}
