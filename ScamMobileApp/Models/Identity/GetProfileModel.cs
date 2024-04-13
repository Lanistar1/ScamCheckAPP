using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Identity
{
    public class GetProfileData
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string role { get; set; }
        public bool isVerified { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
        public string forgotPasswordCode { get; set; }
        public string name
        {
            get
            {
                return firstname + " " + lastname;
            }
        }
    }

    public class GetProfileModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public GetProfileData data { get; set; }
    }


}
