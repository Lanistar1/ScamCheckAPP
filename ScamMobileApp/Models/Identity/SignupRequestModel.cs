using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Identity
{
    public class SignupRequestModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string ageBracket { get; set; }
    }

}
