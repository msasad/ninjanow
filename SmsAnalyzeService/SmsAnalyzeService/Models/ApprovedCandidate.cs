using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public class ApprovedCandidate
    {
        public String Id { get; private set; }
        public void setLoanIdValue()
        {
            Id = Guid.NewGuid().ToString();
        }
        public String Name { get; set; }
        public String UID { get; set; }
        public bool approved { get; private set;} = false;
        public double score { get; set; }
        public List<LoanCandidate> loanReferred { get; set; }

        public void SetApprovedProp(bool approved) {
            this.approved = approved; 
        }
    }
}