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


        //public string Output
        //{
        //    get
        //    {
        //        if (output == "Likely a scam" || output.Contains("Likely a scam") )
        //        {
        //            SubColor = Color.FromHex("FF0000");
        //            return output;
        //        }
        //        else
        //        {
        //            SubColor = Color.FromHex("4CC98D");
        //            return output;
        //        }
        //    }
        //    set
        //    {
        //        Output = value;
        //    }
        //}

        public Color SubColor
        {
            get
            {
                if (output == "Likely a scam" || output.Contains("Likely a scam"))
                {
                    Color source1 = Color.FromHex("FF0000");
                    return source1;
                }
                else
                {
                    Color source2 = Color.FromHex("4CC98D");
                    return source2;
                }
            }
            set
            {
                SubColor = value;
            }
        }

        //public Color SubColor { get; set; }

        public ImageSource TransImage
        {
            get
            {
                if (output == "Likely a scam" || output.Contains("Likely a scam"))
                {
                    ImageSource source1 = ImageSource.FromFile("scamredlogo.png");
                    return source1;
                }
                else
                {
                    ImageSource source = ImageSource.FromFile("scamgreenlogo.png");
                    return source;
                }

            }
            set { TransImage = value; }
        }


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
