using System;
using System.Collections.Generic;
using System.Text;

namespace ScamMobileApp.Models.Others
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AIImageCheckData
    {
        public string status { get; set; }
        public Request request { get; set; }
        public Type type { get; set; }
        public Media media { get; set; }
    }

    public class Media
    {
        public string id { get; set; }
        public string uri { get; set; }
    }

    public class Request
    {
        public string id { get; set; }
        public double timestamp { get; set; }
        public int operations { get; set; }
    }

    public class AIImageCheckModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public AIImageCheckData data { get; set; }
    }

    public class Type
    {
        public double ai_generated { get; set; }
    }



}
