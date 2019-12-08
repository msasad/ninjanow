using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public class SocialFriendCreditScore : GrabCreditScoreBase
    {
        public SocialFriendCreditScore() : base (ScoreValidatorType.SocialWebSiteProcessor){

        }

        internal void updateScore(double v)
        {
           score = score + v;
        }


    }
}