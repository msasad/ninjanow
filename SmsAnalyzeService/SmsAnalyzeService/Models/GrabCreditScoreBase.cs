using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public abstract class GrabCreditScoreBase
    {
        public ScoreValidatorType type { get; protected set; }

        protected GrabCreditScoreBase(ScoreValidatorType type) {
            this.type = type;
        }

        public double score;

        public double weightForScore = 1.0;

    }
}