﻿using ScamMobileApp.Models.Identity;
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


        public static ProfileData UserData;
        public static string Token;

        public static bool Contains(this string target, string value, StringComparison comparison)
        {
            return target.IndexOf(value, comparison) >= 0;
        }
    }
}
