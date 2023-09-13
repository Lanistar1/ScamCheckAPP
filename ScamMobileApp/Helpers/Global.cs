using ScamMobileApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Helpers
{
    public static class Global
    {
        public static string BaseUrl => "https://scam-detector.onrender.com";

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



        public static ProfileData UserData;
        public static GetProfileData UserProfileData { get; set; }
        public static string Token;

        public static int firstTest;
        public static int seconTest;
        public static int thirdTest;

        public static bool Contains(this string target, string value, StringComparison comparison)
        {
            return target.IndexOf(value, comparison) >= 0;
        }
    }
}
