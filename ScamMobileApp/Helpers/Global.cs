using ScamMobileApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Helpers
{
    public static class Global
    {
        //public static string BaseUrl => "https://scam-detector.onrender.com";
        //public static string BaseUrl => "http://174.138.48.250:3000";
        //public static string BaseUrl => "http://209.97.184.81:5000";
        public static string BaseUrl => "https://server.thescamalicious.com";


        public static string LoginUrl => $"{BaseUrl}/auth/login";
        public static string SignupUrl => $"{BaseUrl}/auth/signup";
        public static string ChangePasswordUrl => $"{BaseUrl}/auth/change-password";
        public static string ForgotPassswordUrl => $"{BaseUrl}/auth/forgot-password";
        public static string ResetPassswordUrl => $"{BaseUrl}/auth/reset-password";
        public static string GetProfileUrl => $"{BaseUrl}/auth/user";
        public static string PostExperienceUrl => $"{BaseUrl}/experience";
        public static string GetExperienceUrl => $"{BaseUrl}/experience";
        public static string PostFeedbackUrl => $"{BaseUrl}/feedback";
        public static string GetFeedbackUrl => $"{BaseUrl}/feedback/user/all";
        public static string DeleteProfileUrl => $"{BaseUrl}/auth/delete-account";
        public static string PickFileUrl => $"{BaseUrl}/auth/upload-image";
        public static string ContactAdminUrl => $"{BaseUrl}/auth/contact-admin";
        public static string FeedbackCountUrl => $"{BaseUrl}/feedback/count/all";
        public static string ReportPostUrl => $"{BaseUrl}/experience/report/new";
        public static string BlockUserUrl => $"{BaseUrl}/auth/block-user";
        public static string FlagPostUrl => $"{BaseUrl}/experience/flag/new";
        public static string AddUnwantedKeywordsUrl => $"{BaseUrl}/feedback/unwanted/keywords";
        public static string GetUnwantedKeywordsUrl => $"{BaseUrl}/feedback/unwanted/keywords";
        public static string PostAppRatingUrl => $"{BaseUrl}/feedback/rate/new";
        public static string NewsUrl => "https://newsapi.org/v2/top-headlines?country=us&apiKey=aae4b3c2c26042a9b4d5ad99afafe4c5";






        public static ProfileData UserData;
        public static GetProfileData UserProfileData { get; set; }
        public static string Token;

        public static int firstTest;
        public static int seconTest;
        public static int thirdTest;
        public static string newResult1;
        public static string newResult2;
        public static string newResult3;
        public static string newResult4;
        public static string NewScamResult;
        public static string likelyOrNot;
        public static int Rating;
        public static string comment;
        public static string UserName;
        public static string firstName;
        public static int newRatingNumber;
        public static DateTime DateType { get; set; }


        public static bool Contains(this string target, string value, StringComparison comparison)
        {
            return target.IndexOf(value, comparison) >= 0;
        }
    }
}
