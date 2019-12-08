using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public enum ScoreValidatorType {
        SmsProcessor,
        GeologicalProcessor,
        SocialWebSiteProcessor
    }

    public class TextMessage
    {
        public string messageId { get; set; }
        public string MessageBody { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime SentTime { get; set; }


    }
}