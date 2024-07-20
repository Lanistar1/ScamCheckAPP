using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Identity
{
    public class Data
    {
        public string url { get; set; }
    }

    public class pickImageResponseModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }


}
