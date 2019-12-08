using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public class SmsScoreComputerInpute: ScoreComputerBaseInpute
    {
        public List<TextMessage> Message { get; set; }
    }
}