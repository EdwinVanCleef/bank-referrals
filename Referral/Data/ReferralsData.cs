using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Referral.Models;

namespace Referral.Data
{
    public class ReferralsData
    {
        public static List<Referrals> ReferralsList = new List<Referrals>()
        {
            new Referrals() {ReferralDate = DateTime.Now, RefferalId = 1, 
                UserId = 1, ReferredId = 2}
        };
    }
}
