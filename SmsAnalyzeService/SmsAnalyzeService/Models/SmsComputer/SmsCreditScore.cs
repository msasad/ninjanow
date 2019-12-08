using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public class SmsCreditScore : GrabCreditScoreBase
    {
        public SmsCreditScore() : base(ScoreValidatorType.SmsProcessor)
        {

        }

        internal void updateScore(double v)
        {
            score = score + v;
        }
    }
}