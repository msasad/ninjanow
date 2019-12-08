using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{

    public class FriendCandidate
    {
        public String Name { get; set; }
        public String UID { get; set; }
        public bool Approved { get; private set;} = false;
        public double TraditionScore { get; set; } = 200;
        public double GrabScore { get; set; } = 200;
        public void SetApprovedProp(bool approved) {
            this.Approved = approved; 
        }

    }
}