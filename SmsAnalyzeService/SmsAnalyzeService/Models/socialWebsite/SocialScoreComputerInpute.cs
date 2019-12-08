using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public class SocialScoreComputerInpute: ScoreComputerBaseInpute
    {
        //Friend Id
        public List<String> FriendUids { get; set; }
    }
}