using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationAPI.Models
{
    public class GlobalModel
    {
        public class GlobalMessage
        {
            public string status { get; set; }
            public string errorMssage { get; set; }
            public List<Message> listMessage { get; set; }
        }
        public class Message
        {
            public int id { get; set; }
            public string title { get; set; }
        }

    }
}