using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ScamMobileApp.Models.Feedback
{

    public class GetFeedbackData
    {
        public string _id { get; set; }
        public string email { get; set; }
        public object comment { get; set; }
        public int rating { get; set; }
        public List<QuestionAnswer> questionAnswer { get; set; }
        public string output { get; set; }
        public string outputDetails { get; set; }
        public string scamType { get; set; }
        public string userId { get; set; }
        public UserDetails userDetails { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
        public bool isSelected { get; set; }

        public string newDate
        {
            get
            {
                return createdAt.Date.ToShortDateString();
                //Console.WriteLine(createdAt);
                //return newDate;
            }
            set
            {
                newDate = value;
            }
        }

        public TimeSpan newTime
        {
            get
            {
                return createdAt.TimeOfDay;
                //Console.WriteLine(createdAt);
                //return newDate;
            }
            set
            {
                newTime = value;
            }
        }


        public string NewOutput
        {
            get
            {
                if (output == "Likely a scam")
                {
                    SubColor = Color.FromHex("FF0000");
                    return output;
                }
                else
                {
                    SubColor = Color.FromHex("4CC98D");
                    return output;
                }
            }
            set
            {
                NewOutput = value;
            }
        }

        public Color SubColor { get; set; }


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
        public ObservableCollection<GetFeedbackData> data { get; set; }
    }

    public class UserDetails
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string _id { get; set; }
        public string username { get; set; }
    }

}
