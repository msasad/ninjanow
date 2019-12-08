using SmsAnalyzeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmsAnalyzeService.service
{
    public static class RepositoryService
    {

        //loan Id vers loans
        public static Dictionary<string, LoanCandidate> loan { get; set; } 
            = new Dictionary<string, LoanCandidate>();

        //candidate Id vers loans
        public static Dictionary<string, LoanCandidate> candidateLoan { get; set; }
            = new Dictionary<string, LoanCandidate>();

        //loan Id vers friends
        public static Dictionary<string, FriendCandidate> refferalLaonTofriend { get; set; }
            = new Dictionary<string, FriendCandidate>();

        internal static FriendCandidate GetFriend(string f)
        {
            if(friend.ContainsKey(f))
            {
                friend.TryGetValue(f, out var ans);
                return ans;
            }
            return null;
        }


        //friend Id vers loans
        public static Dictionary<string, FriendCandidate> friend { get; set; } 
            = new Dictionary<string, FriendCandidate>();

        public static void init() {
            initFriends();
            initLoan();
        }
        public  static void initFriends() {

            FriendCandidate ganesh = new FriendCandidate();
            ganesh.Name = "Ganesh";
            ganesh.GrabScore = 400;
            ganesh.TraditionScore = 400;
            ganesh.SetApprovedProp(true);
            ganesh.UID = "UID_ganesh";

            FriendCandidate abdul = new FriendCandidate();
            abdul.Name = "abdul";
            abdul.GrabScore = 100;
            abdul.TraditionScore = 100;
            abdul.SetApprovedProp(true);
            abdul.UID = "UID_abdul";

            if (!friend.ContainsKey(ganesh.UID))
            {
                friend.Add(ganesh.UID, ganesh);
            }

            if (!friend.ContainsKey(abdul.UID))
            {
                friend.Add(abdul.UID, abdul);
            }
        }

        public static void initLoan()
        {
            LoanCandidate sid = new LoanCandidate();
            sid.PersonName = "Sid";
            sid.UID = "sid_uid";
            sid.refferal = new List<string> { "UID_abdul" };
        }


     

    }
}