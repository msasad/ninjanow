using SmsAnalyzeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsAnalyzeService.Areas.HelpPage.service
{

    public class SocialWebsiteScoreComputer : IScoreComputer<SocialScoreComputerInpute, SocialFriendCreditScore>
    {
        public SocialFriendCreditScore Calculate(SocialScoreComputerInpute input) {
            //TotalPersonCount = 1000;
            SocialFriendCreditScore socialFriend = new SocialFriendCreditScore();
            int totalCount = 100;
            double score = 0;
            foreach (var f in input.FriendUids) {
                FriendCandidate candidate = SmsAnalyzeService.service.RepositoryService.GetFriend(f);
                if (candidate != null)
                {
                    score = score + (candidate.TraditionScore);
                }
                else {
                    totalCount--; 
                }
                
            }
            socialFriend.updateScore(score / totalCount);
            return socialFriend;
        }
    }
}
