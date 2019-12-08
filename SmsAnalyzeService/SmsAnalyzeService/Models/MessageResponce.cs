using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public class MessageApiResponce
    {
        public int MessageId { get; set; }
        public object data { get; set; }
        public bool success { get; set; }

        public MessageApiResponce(bool success , string data)
        {
            this.success = success;
            this.data = data;
        }
    }
}