using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Identity
{

    public class UserData
    {
        public ProfileData profile { get; set; }
        public string token { get; set; }
    }

    public class ProfileData
    {
        public string memberId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool isVerified { get; set; }
        public string role { get; set; }
    }

    public class LoginResponseModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public UserData data { get; set; }
    }


}
