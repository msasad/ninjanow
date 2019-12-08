using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.Models
{
    public class LoanCandidate
    {
        public String PersonName { get; set; }
        public String UID { get; set; }
        public String Id { get; private set; }
        public List<string> refferal { get; set; }

        public LoanCandidate() {
            this.setLoanIdValue();
        }
        public void setLoanIdValue() {
            Id = Guid.NewGuid().ToString();
        }

    }
}